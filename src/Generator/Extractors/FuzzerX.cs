using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Generator.Tools;
using Iced.Intel;
using E = Generator.Tools.ExtTool;
using static Iced.Intel.AssemblerRegisters;
using A = Iced.Intel.Assembler;
using AR8 = Iced.Intel.AssemblerRegister8;
using AR16 = Iced.Intel.AssemblerRegister16;
using AMO = Iced.Intel.AssemblerMemoryOperand;

// ReSharper disable RedundantCast

namespace Generator.Extractors
{
    public static class FuzzerX
    {
        public static byte[]? Assemble(Action<A> action)
        {
            var asm = new A(16);
            action(asm);
            using var mem = new MemoryStream();
            var writer = new StreamCodeWriter(mem);
            try
            {
                asm.Assemble(writer, 0);
            }
            catch (InvalidOperationException)
            {
                return null;
            }
            return mem.ToArray();
        }

        public static byte[][] GetAllCandidates(bool withNum = true)
        {
            var num08 = IterTool.Iter8Bit().Select(BitTool.AsByte);
            var num16 = IterTool.Iter16Bit().Select(BitTool.AsShort);
            var numbers = withNum ? num08.Concat(num16) : [];
            var cands = numbers.AddFuzzy().ToArray();
            return cands;
        }

        private static IEnumerable<byte[]> AddFuzzy(this IEnumerable<byte[]> bytes)
        {
            var dict = new SortedDictionary<string, byte[]>();
            Fuzzer.DoAll(a =>
            {
                if (Assemble(a) is not { } bits)
                    return;
                dict[Convert.ToHexString(bits)] = bits;
            });
            foreach (var bits in GoAll())
            {
                dict[Convert.ToHexString(bits)] = bits;
            }
            foreach (var bits in bytes)
            {
                dict[Convert.ToHexString(bits)] = bits;
            }
            return dict.Values;
        }

        private static IEnumerable<byte[]> GoAll()
        {
            return Generate().Where(b => b != null).Cast<byte[]>();
        }

        private static IEnumerable<byte[]?> IterR8B(Action<A, AR8, byte> func)
        {
            foreach (var (b, c) in new[]
                     {
                         (ah, (byte)7),
                         (bl, (byte)10),
                         (ch, (byte)13),
                         (dl, (byte)19)
                     })
                yield return E.GetBytes(a => func(a, b, c));
        }

        private static IEnumerable<byte[]?> IterUl(Action<A, ulong> func)
        {
            foreach (var it in new ulong[] { 0, 3, 7, 9, 10, 13 })
                yield return E.GetBytes(a => func(a, it));
        }

        private static IEnumerable<byte[]?> IterUb(Action<A, byte> func)
        {
            foreach (var it in new byte[] { 0, 3, 7, 9, 10, 13 })
                yield return E.GetBytes(a => func(a, it));
        }

        private static IEnumerable<byte[]?> IterR8(Action<A, AR8> func)
        {
            foreach (var it in new[]
                     {
                         ah, al, bh, bl, ch, cl, dh, dl
                     })
                yield return E.GetBytes(a => func(a, it));
        }

        private static IEnumerable<byte[]?> IterSsb(Action<A, short, sbyte> func)
        {
            foreach (var (b, c) in new[]
                     {
                         ((short)9, (sbyte)17),
                         ((short)19, (sbyte)7),
                         ((short)29, (sbyte)37),
                         ((short)59, (sbyte)47)
                     })
                yield return E.GetBytes(a => func(a, b, c));
        }

        private static IEnumerable<byte[]?> IterR16(Action<A, AR16> func)
        {
            foreach (var it in new[]
                     {
                         ax, bx, cx, dx, bp, sp, di, si
                     })
                yield return E.GetBytes(a => func(a, it));
        }

        private static IEnumerable<byte[]?> Iter16M(Action<A, AR16, AMO> func)
        {
            foreach (var (b, c) in new[]
                     {
                         (ax, __word_ptr[bx]),
                         (bx, __word_ptr[ax]),
                         (ax, __byte_ptr[bx]),
                         (bx, __byte_ptr[ax])
                     })
                yield return E.GetBytes(a => func(a, b, c));
        }

        private static IEnumerable<byte[]?> Iter1616(Action<A, AR16, AR16> func)
        {
            foreach (var (b, c) in new[]
                     {
                         (ax, bx),
                         (bx, ax),
                         (dx, cx),
                         (bx, dx)
                     })
                yield return E.GetBytes(a => func(a, b, c));
        }

        private static IEnumerable<byte[]?> IterNone(Action<A> func)
        {
            yield return func.GetBytes();
        }

        private static IEnumerable<byte[]?> Generate()
        {
            foreach (var items in new[]
                     {
                         IterNone(a => a.aaa()),
                         IterNone((a) => a.aad(0x0A)),
                         IterNone(a => a.aad(10)),
                         IterNone((a) => a.aam(0x0A)),
                         IterNone(a => a.aam(10)),
                         IterNone(a => a.aas()),
                         Iter1616((a, b, c) => a.adc(b, c)),
                         IterNone(a => a.adc(bx, 9)),
                         IterNone(a => a.add(ah, bh)),
                         Iter1616((a, b, c) => a.add(b, c)),
                         Iter1616((a, b, c) => a.and(b, c)),
                         IterNone(a => a.and(bx, ax)),
                         Iter16M((a, b, c) => a.bound(b, c)),
                         IterNone(a => a.call(9)),
                         IterR16((a, b) => a.call(b)),
                         IterNone(a => a.cbw()),
                         IterNone(a => a.clc()),
                         IterNone(a => a.cld()),
                         IterNone(a => a.cli()),
                         IterNone(a => a.cmc()),
                         IterNone(a => a.cmp(ah, 9)),
                         IterR8((a, b) => a.cmp(b, b)),
                         IterNone(a => a.cmpsb()),
                         IterNone(a => a.cmpsw()),
                         IterNone(a => a.cwd()),
                         IterNone(a => a.daa()),
                         IterNone(a => a.das()),
                         IterNone(a => a.dec(ah)),
                         IterR16((a, b) => a.dec(b)),
                         IterR16((a, b) => a.div(b)),
                         IterNone(a => a.div(bx)),
                         IterNone(a => a.enter(19, 39)),
                         IterSsb((a, b, c) => a.enter(b, c)),
                         IterNone(a => a.hlt()),
                         IterNone(a => a.idiv(ah)),
                         IterR16((a, b) => a.idiv(b)),
                         IterR16((a, b) => a.imul(b)),
                         IterNone(a => a.imul(bh)),
                         IterR8B((a, b, c) => a.@in(b, c)),
                         IterNone(a => a.inc(ah)),
                         IterR8((a, b) => a.inc(b)),
                         IterNone(a => a.insb()),
                         IterNone(a => a.insw()),
                         IterNone(a => a.@int(9)),
                         IterUb((a, b) => a.@int(b)),
                         IterNone(a => a.int3()),
                         IterNone(a => a.into()),
                         IterNone(a => a.iret()),
                         IterNone(a => a.ja(2)),
                         IterUl((a, b) => a.ja(b)),
                         IterNone(a => a.jae(1)),
                         IterNone(a => a.jb(4)),
                         IterNone(a => a.jbe(3)),
                         IterUl((a, b) => a.jbe(b)),
                         IterUl((a, b) => a.jc(b)),
                         IterNone(a => a.jcxz(5)),
                         IterUl((a, b) => a.jcxz(b)),
                         IterNone(a => a.je(6)),
                         IterNone(a => a.jg(8)),
                         IterUl((a, b) => a.jg(b)),
                         IterNone(a => a.jge(7)),
                         IterUl((a, b) => a.jge(b)),
                         IterNone(a => a.jl(10)),
                         IterUl((a, b) => a.jl(b)),
                         IterNone(a => a.jle(9)),
                         IterUl((a, b) => a.jle(b)),
                         IterR16((a, b) => a.jmp(b)),
                         IterNone(a => a.jmp(bx)),
                         IterUl((a, b) => a.jnc(b)),
                         IterNone(a => a.jne(1)),
                         IterNone(a => a.jno(2)),
                         IterUl((a, b) => a.jno(b)),
                         IterNone(a => a.jnp(3)),
                         IterUl((a, b) => a.jnp(b)),
                         IterNone(a => a.jns(4)),
                         IterUl((a, b) => a.jns(b)),
                         IterUl((a, b) => a.jnz(b)),
                         IterNone(a => a.jo(5)),
                         IterUl((a, b) => a.jo(b)),
                         IterNone(a => a.jp(6)),
                         IterUl((a, b) => a.jp(b)),
                         IterNone(a => a.js(7)),
                         IterUl((a, b) => a.js(b)),
                         IterUl((a, b) => a.jz(b)),
                         IterNone(a => a.lahf()),
                         Iter16M((a, b, c) => a.lds(b, c)),
                         Iter16M((a, b, c) => a.lea(b, c)),
                         IterNone(a => a.leave()),
                         Iter16M((a, b, c) => a.les(b, c)),
                         IterNone(a => a.@lock.aaa()),
                         IterNone(a => a.@lock.aad(10)),
                         IterNone(a => a.@lock.aam(10)),
                         IterNone(a => a.@lock.adc(bx, 9)),
                         IterNone(a => a.@lock.add(ah, bh)),
                         IterNone(a => a.@lock.and(bx, ax)),
                         IterNone(a => a.@lock.call(9)),
                         IterNone(a => a.@lock.cbw()),
                         IterNone(a => a.@lock.clc()),
                         IterNone(a => a.@lock.cld()),
                         IterNone(a => a.@lock.cli()),
                         IterNone(a => a.@lock.cmc()),
                         IterNone(a => a.@lock.cmp(ah, 9)),
                         IterNone(a => a.@lock.cmpsb()),
                         IterNone(a => a.@lock.cmpsw()),
                         IterNone(a => a.@lock.cwd()),
                         IterNone(a => a.@lock.daa()),
                         IterNone(a => a.@lock.das()),
                         IterNone(a => a.@lock.dec(ah)),
                         IterNone(a => a.@lock.div(bx)),
                         IterNone(a => a.@lock.enter(19, 39)),
                         IterNone(a => a.@lock.hlt()),
                         IterNone(a => a.@lock.idiv(ah)),
                         IterNone(a => a.@lock.imul(bh)),
                         IterNone(a => a.@lock.inc(ah)),
                         IterNone(a => a.@lock.insb()),
                         IterNone(a => a.@lock.insw()),
                         IterNone(a => a.@lock.@int(9)),
                         IterNone(a => a.@lock.into()),
                         IterNone(a => a.@lock.iret()),
                         IterNone(a => a.@lock.ja(2)),
                         IterNone(a => a.@lock.jae(1)),
                         IterNone(a => a.@lock.jb(4)),
                         IterNone(a => a.@lock.jbe(3)),
                         IterNone(a => a.@lock.jcxz(5)),
                         IterNone(a => a.@lock.je(6)),
                         IterNone(a => a.@lock.jg(8)),
                         IterNone(a => a.@lock.jge(7)),
                         IterNone(a => a.@lock.jl(10)),
                         IterNone(a => a.@lock.jle(9)),
                         IterNone(a => a.@lock.jmp(bx)),
                         IterNone(a => a.@lock.jne(1)),
                         IterNone(a => a.@lock.jno(2)),
                         IterNone(a => a.@lock.jnp(3)),
                         IterNone(a => a.@lock.jns(4)),
                         IterNone(a => a.@lock.jo(5)),
                         IterNone(a => a.@lock.jp(6)),
                         IterNone(a => a.@lock.js(7)),
                         IterNone(a => a.@lock.lahf()),
                         IterNone(a => a.@lock.leave()),
                         IterNone(a => a.@lock.lodsb()),
                         IterNone(a => a.@lock.lodsw()),
                         IterNone(a => a.@lock.loop(3)),
                         IterNone(a => a.@lock.loope(5)),
                         IterNone(a => a.@lock.loopne(6)),
                         IterNone(a => a.@lock.mov(ah, 9)),
                         IterNone(a => a.@lock.movsb()),
                         IterNone(a => a.@lock.movsw()),
                         IterNone(a => a.@lock.mul(ah)),
                         IterNone(a => a.@lock.neg(bh)),
                         IterNone(a => a.@lock.nop()),
                         IterNone(a => a.@lock.not(ah)),
                         IterNone(a => a.@lock.or(ah, 42)),
                         IterNone(a => a.@lock.outsb()),
                         IterNone(a => a.@lock.outsw()),
                         IterNone(a => a.@lock.pop(bx)),
                         IterNone(a => a.@lock.popa()),
                         IterNone(a => a.@lock.popf()),
                         IterNone(a => a.@lock.push(6)),
                         IterNone(a => a.@lock.push(bx)),
                         IterNone(a => a.@lock.pusha()),
                         IterNone(a => a.@lock.pushf()),
                         IterNone(a => a.@lock.rcl(ah, 3)),
                         IterNone(a => a.@lock.rcr(ah, 4)),
                         IterNone(a => a.@lock.ret()),
                         IterNone(a => a.@lock.ret(87)),
                         IterNone(a => a.@lock.retf()),
                         IterNone(a => a.@lock.retf(35)),
                         IterNone(a => a.@lock.rol(ah, 13)),
                         IterNone(a => a.@lock.ror(bh, 24)),
                         IterNone(a => a.@lock.sahf()),
                         IterNone(a => a.@lock.sar(ah, 4)),
                         IterNone(a => a.@lock.sbb(ah, 3)),
                         IterNone(a => a.@lock.scasb()),
                         IterNone(a => a.@lock.scasw()),
                         IterNone(a => a.@lock.shl(ah, 31)),
                         IterNone(a => a.@lock.shr(bx, 25)),
                         IterNone(a => a.@lock.stc()),
                         IterNone(a => a.@lock.std()),
                         IterNone(a => a.@lock.sti()),
                         IterNone(a => a.@lock.stosb()),
                         IterNone(a => a.@lock.stosw()),
                         IterNone(a => a.@lock.sub(ah, bh)),
                         IterNone(a => a.@lock.test(ah, 9)),
                         IterNone(a => a.@lock.wait()),
                         IterNone(a => a.@lock.xchg(bx, ax)),
                         IterNone(a => a.@lock.xlatb()),
                         IterNone(a => a.@lock.xor(ch, 9)),
                         IterNone(a => a.lodsb()),
                         IterNone(a => a.lodsw()),
                         IterNone(a => a.loop(3)),
                         IterUl((a, b) => a.loop(b)),
                         IterNone(a => a.loope(5)),
                         IterUl((a, b) => a.loope(b)),
                         IterNone(a => a.loopne(6)),
                         IterUl((a, b) => a.loopne(b)),
                         IterNone(a => a.mov(ah, 9)),
                         Iter1616((a, b, c) => a.mov(b, c)),
                         IterNone(a => a.movsb()),
                         IterNone(a => a.movsw()),
                         IterNone(a => a.mul(ah)),
                         IterR16((a, b) => a.mul(b)),
                         IterR16((a, b) => a.neg(b)),
                         IterNone(a => a.neg(bh)),
                         IterNone(a => a.nop()),
                         IterNone(a => a.not(ah)),
                         IterR16((a, b) => a.not(b)),
                         IterNone(a => a.or(ah, 42)),
                         Iter1616((a, b, c) => a.or(b, c)),
                         Iter1616((a, b, c) => a.@out(b, c)),
                         IterNone(a => a.outsb()),
                         IterNone(a => a.outsw()),
                         IterR16((a, b) => a.pop(b)),
                         IterNone(a => a.pop(bx)),
                         IterNone(a => a.popa()),
                         IterNone(a => a.popf()),
                         IterNone(a => a.push(6)),
                         IterR16((a, b) => a.push(b)),
                         IterNone(a => a.push(bx)),
                         IterNone(a => a.pusha()),
                         IterNone(a => a.pushf()),
                         IterNone(a => a.rcl(ah, 3)),
                         IterR8((a, b) => a.rcl(b, 8)),
                         IterNone(a => a.rcr(ah, 4)),
                         IterR8((a, b) => a.rcr(b, 8)),
                         IterNone(a => a.rep.insb()),
                         IterNone(a => a.rep.insw()),
                         IterNone(a => a.rep.lodsb()),
                         IterNone(a => a.rep.lodsw()),
                         IterNone(a => a.rep.movsb()),
                         IterNone(a => a.rep.movsw()),
                         IterNone(a => a.rep.outsb()),
                         IterNone(a => a.rep.outsw()),
                         IterNone(a => a.rep.ret()),
                         IterNone(a => a.rep.stosb()),
                         IterNone(a => a.rep.stosw()),
                         IterNone(a => a.repe.cmpsb()),
                         IterNone(a => a.repe.cmpsw()),
                         IterNone(a => a.repe.scasb()),
                         IterNone(a => a.repe.scasw()),
                         IterNone(a => a.repne.cmpsb()),
                         IterNone(a => a.repne.cmpsw()),
                         IterNone(a => a.repne.insb()),
                         IterNone(a => a.repne.insw()),
                         IterNone(a => a.repne.lodsb()),
                         IterNone(a => a.repne.lodsw()),
                         IterNone(a => a.repne.movsb()),
                         IterNone(a => a.repne.movsw()),
                         IterNone(a => a.repne.outsb()),
                         IterNone(a => a.repne.outsw()),
                         IterNone(a => a.repne.scasb()),
                         IterNone(a => a.repne.scasw()),
                         IterNone(a => a.repne.stosb()),
                         IterNone(a => a.repne.stosw()),
                         IterNone(a => a.ret()),
                         IterNone(a => a.ret(87)),
                         IterNone(a => a.retf()),
                         IterNone(a => a.retf(35)),
                         IterNone(a => a.rol(ah, 13)),
                         IterR8((a, b) => a.rol(b, 8)),
                         IterR8((a, b) => a.ror(b, 8)),
                         IterNone(a => a.ror(bh, 24)),
                         IterNone(a => a.sahf()),
                         IterNone(a => a.sar(ah, 4)),
                         IterR8((a, b) => a.sar(b, 8)),
                         IterNone(a => a.sbb(ah, 3)),
                         IterR8((a, b) => a.sbb(b, 8)),
                         IterNone(a => a.scasb()),
                         IterNone(a => a.scasw()),
                         IterNone(a => a.shl(ah, 31)),
                         IterR8((a, b) => a.shl(b, 8)),
                         IterR8((a, b) => a.shr(b, 8)),
                         IterNone(a => a.shr(bx, 25)),
                         IterNone(a => a.stc()),
                         IterNone(a => a.std()),
                         IterNone(a => a.sti()),
                         IterNone(a => a.stosb()),
                         IterNone(a => a.stosw()),
                         IterNone(a => a.sub(ah, bh)),
                         IterR8((a, b) => a.sub(b, 8)),
                         IterNone(a => a.test(ah, 9)),
                         IterR8((a, b) => a.test(b, 8)),
                         IterNone(a => a.wait()),
                         IterR8((a, b) => a.xchg(b, b)),
                         IterNone(a => a.xchg(bx, ax)),
                         IterNone(a => a.xlatb()),
                         IterR8((a, b) => a.xor(b, b)),
                         IterNone(a => a.xor(ch, 9))
                     })
            foreach (var item in items)
                yield return item;
        }
    }
}