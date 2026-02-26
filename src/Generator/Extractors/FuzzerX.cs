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
        private static byte[]? Assemble(Action<A> action)
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

        public static IEnumerable<byte[]> AddFuzzy(this IEnumerable<byte[]> bytes)
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
            return bytes.Concat(dict.Values);
        }
        
        private static IEnumerable<byte[]> GoAll()
        {
            return Generate().Where(b => b != null).Cast<byte[]>();
        }

        private static IEnumerable<byte[]?> IterR8B(Action<A, AR8, byte> func)
        {
            foreach (var (b, c) in new[]
                     {
                         (ah, (byte)7)
                     })
                yield return E.GetBytes(a => func(a, b, c));
        }

        private static IEnumerable<byte[]?> IterUl(Action<A, ulong> func)
        {
            foreach (var it in new ulong[] { 0, 3, 7, 9, 13 })
                yield return E.GetBytes(a => func(a, it));
        }

        private static IEnumerable<byte[]?> IterUb(Action<A, byte> func)
        {
            foreach (var it in new byte[] { 0, 3, 7, 9, 13 })
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
                         ((short)9, (sbyte)7)
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
                         (ax, __word_ptr[bx])
                     })
                yield return E.GetBytes(a => func(a, b, c));
        }

        private static IEnumerable<byte[]?> Iter1616(Action<A, AR16, AR16> func)
        {
            foreach (var (b, c) in new[]
                     {
                         (ax, bx)
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
                         IterNone((a) => a.aam(0x0A)),
                         IterNone(a => a.aas()),
                         Iter1616((a, b, c) => a.adc(b, c)),
                         Iter1616((a, b, c) => a.add(b, c)),
                         Iter1616((a, b, c) => a.and(b, c)),
                         Iter16M((a, b, c) => a.bound(b, c)),
                         IterR16((a, b) => a.call(b)),
                         IterNone(a => a.cbw()),
                         IterNone(a => a.clc()),
                         IterNone(a => a.cld()),
                         IterNone(a => a.cli()),
                         IterNone(a => a.cmc()),
                         IterR8((a, b) => a.cmp(b, b)),
                         IterNone(a => a.cmpsb()),
                         IterNone(a => a.cmpsw()),
                         IterNone(a => a.cwd()),
                         IterNone(a => a.daa()),
                         IterNone(a => a.das()),
                         IterR16((a, b) => a.dec(b)),
                         IterR16((a, b) => a.div(b)),
                         IterSsb((a, b, c) => a.enter(b, c)),
                         IterNone(a => a.hlt()),
                         IterR16((a, b) => a.idiv(b)),
                         IterR16((a, b) => a.imul(b)),
                         IterR8B((a, b, c) => a.@in(b, c)),
                         IterR8((a, b) => a.inc(b)),
                         IterNone(a => a.insb()),
                         IterNone(a => a.insw()),
                         IterUb((a, b) => a.@int(b)),
                         IterNone(a => a.into()),
                         IterNone(a => a.int3()),
                         IterNone(a => a.iret()),
                         IterUl((a, b) => a.ja(b)),
                         IterUl((a, b) => a.jbe(b)),
                         IterUl((a, b) => a.jc(b)),
                         IterUl((a, b) => a.jcxz(b)),
                         IterUl((a, b) => a.jg(b)),
                         IterUl((a, b) => a.jge(b)),
                         IterUl((a, b) => a.jl(b)),
                         IterUl((a, b) => a.jle(b)),
                         IterR16((a, b) => a.jmp(b)),
                         IterUl((a, b) => a.jnc(b)),
                         IterUl((a, b) => a.jno(b)),
                         IterUl((a, b) => a.jnp(b)),
                         IterUl((a, b) => a.jns(b)),
                         IterUl((a, b) => a.jnz(b)),
                         IterUl((a, b) => a.jo(b)),
                         IterUl((a, b) => a.jp(b)),
                         IterUl((a, b) => a.js(b)),
                         IterUl((a, b) => a.jz(b)),
                         IterNone(a => a.lahf()),
                         Iter16M((a, b, c) => a.lds(b, c)),
                         Iter16M((a, b, c) => a.lea(b, c)),
                         IterNone(a => a.leave()),
                         Iter16M((a, b, c) => a.les(b, c)),
                         IterNone(a => a.lodsb()),
                         IterNone(a => a.lodsw()),
                         IterUl((a, b) => a.loop(b)),
                         IterUl((a, b) => a.loope(b)),
                         IterUl((a, b) => a.loopne(b)),
                         Iter1616((a, b, c) => a.mov(b, c)),
                         IterNone(a => a.movsb()),
                         IterNone(a => a.movsw()),
                         IterR16((a, b) => a.mul(b)),
                         IterR16((a, b) => a.neg(b)),
                         IterNone(a => a.nop()),
                         IterR16((a, b) => a.not(b)),
                         Iter1616((a, b, c) => a.or(b, c)),
                         Iter1616((a, b, c) => a.@out(b, c)),
                         IterNone(a => a.outsb()),
                         IterNone(a => a.outsw()),
                         IterR16((a, b) => a.pop(b)),
                         IterNone(a => a.popa()),
                         IterNone(a => a.popf()),
                         IterR16((a, b) => a.push(b)),
                         IterNone(a => a.pusha()),
                         IterNone(a => a.pushf()),
                         IterR8((a, b) => a.rcl(b, 8)),
                         IterR8((a, b) => a.rcr(b, 8)),
                         IterNone(a => a.ret()),
                         IterNone(a => a.retf()),
                         IterR8((a, b) => a.rol(b, 8)),
                         IterR8((a, b) => a.ror(b, 8)),
                         IterNone(a => a.sahf()),
                         IterR8((a, b) => a.sar(b, 8)),
                         IterR8((a, b) => a.sbb(b, 8)),
                         IterNone(a => a.scasb()),
                         IterNone(a => a.scasw()),
                         IterR8((a, b) => a.shl(b, 8)),
                         IterR8((a, b) => a.shr(b, 8)),
                         IterNone(a => a.stc()),
                         IterNone(a => a.std()),
                         IterNone(a => a.sti()),
                         IterNone(a => a.stosb()),
                         IterNone(a => a.stosw()),
                         IterR8((a, b) => a.sub(b, 8)),
                         IterR8((a, b) => a.test(b, 8)),
                         IterNone(a => a.wait()),
                         IterR8((a, b) => a.xchg(b, b)),
                         IterNone(a => a.xlatb()),
                         IterR8((a, b) => a.xor(b, b))
                     })
            foreach (var item in items)
                yield return item;
        }
    }
}