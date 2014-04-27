﻿//******************************************************************************************************
//  GuidSHA1Helper.cs - Gbtc
//
//  Copyright © 2014, Grid Protection Alliance.  All Rights Reserved.
//
//  Licensed to the Grid Protection Alliance (GPA) under one or more contributor license agreements. See
//  the NOTICE file distributed with this work for additional information regarding copyright ownership.
//  The GPA licenses this file to you under the Eclipse Public License -v 1.0 (the "License"); you may
//  not use this file except in compliance with the License. You may obtain a copy of the License at:
//
//      http://www.opensource.org/licenses/eclipse-1.0.php
//
//  Unless agreed to in writing, the subject software distributed under the License is distributed on an
//  "AS-IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. Refer to the
//  License for the specific language governing permissions and limitations.
//
//  Code Modification History:
//  ----------------------------------------------------------------------------------------------------
//  04/27/2014 - Steven E. Chisholm
//       Generated original version of source code.
//
//******************************************************************************************************

using System;

namespace GSF.IO.Checksums
{
    /// <summary>
    /// This class is a helper class to quickly generate a strong hash code for a GUID type.
    /// </summary>
    /// <remarks>
    /// A strong hash function is important in Dictionary Lookups. If the hash is sufficently strong, 
    /// a mod operation over the largest prime can be avoided, thus allowing for faster customized dictionary lookups.
    /// 
    /// Method is the same as taking the first 4 bytes of a SHA1 hashsum, except zero is reserved and converted to 1.
    /// 
    /// Customized implementation is about twice as fast as .NET's and requires no class allocation. 
    /// All memory is allocated on the stack (approximately 400 bytes)
    /// </remarks>
    public unsafe class GuidSHA1Helper
    {
        private const uint Y1 = 0x5a827999;
        private const uint Y2 = 0x6ed9eba1;
        private const uint Y3 = 0x8f1bbcdc;
        private const uint Y4 = 0xca62c1d6;

        /// <summary>
        /// Computes the non-zero hashcode of the <see cref="input"/>.
        /// </summary>
        /// <param name="input"></param>
        /// <returns>
        /// A Non-zero hash of the <see cref="input"/>. If the hash would have been 0, the value 1 is substituded.
        /// </returns>
        public static int ComputeHashCode(Guid input)
        {
            uint* hash = stackalloc uint[5];
            byte* hashBlock = stackalloc byte[80 * 4];

            //Initialize
            hash[0] = 0x67452301;
            hash[1] = 0xefcdab89;
            hash[2] = 0x98badcfe;
            hash[3] = 0x10325476;
            hash[4] = 0xc3d2e1f0;

            //Write GUID to buffer
            *(Guid*)(hashBlock) = input;

            const long bitLength = (16 << 3);
            hashBlock[16] = 128;

            //Clear hash
            for (int x = 17; x < 56; x++)
                hashBlock[x] = 0;

            hashBlock[56] = (byte)(bitLength >> 56);
            hashBlock[57] = (byte)(bitLength >> 48);
            hashBlock[58] = (byte)(bitLength >> 40);
            hashBlock[59] = (byte)(bitLength >> 32);
            hashBlock[60] = (byte)(bitLength >> 24);
            hashBlock[61] = (byte)(bitLength >> 16);
            hashBlock[62] = (byte)(bitLength >> 8);
            hashBlock[63] = (byte)(bitLength);

            if (BitConverter.IsLittleEndian)
                SwapEndianSha((ulong*)hashBlock, (ulong*)hashBlock);
            InternalHashBlock(hash, (uint*)hashBlock);

            //Checksum is bigEndian, read as an interger.
            //Read big endian
            int sum = *((byte*)hash + 0) << 24 |
                      *((byte*)hash + 1) << 16 |
                      *((byte*)hash + 2) << 8 |
                      *((byte*)hash + 3);

            if (sum == 0)
                return 1;
            return sum;
        }

        /// <summary>
        /// Computes the hash of the blocks. Words must already be in big endian format.
        /// </summary>
        /// <param name="hash">the current values of the hash</param>
        /// <param name="words">16 words that are already in big endian format.</param>
        static void InternalHashBlock(uint* hash, uint* words)
        {
            uint a = hash[0];
            uint b = hash[1];
            uint c = hash[2];
            uint d = hash[3];
            uint e = hash[4];
            uint* x = words;
            int i;
            //
            // expand 16 word block into 80 word block.
            //
            for (i = 0; i < 64; i++)
            {
                uint t = x[13] ^ x[8] ^ x[2] ^ x[0];
                x[16] = t << 1 | t >> 31;
                x++;
            }

            //
            // round 1
            //
            x = words;

            for (i = 0; i < 4; i++)
            {
                // E = rotateLeft(A, 5) + F(B, C, D) + E + X[idx++] + Y1
                // B = rotateLeft(B, 30)
                e += (a << 5 | (a >> 27)) + ((b & c) | (~b & d)) + x[0] + Y1; b = b << 30 | (b >> 2);
                d += (e << 5 | (e >> 27)) + ((a & b) | (~a & c)) + x[1] + Y1; a = a << 30 | (a >> 2);
                c += (d << 5 | (d >> 27)) + ((e & a) | (~e & b)) + x[2] + Y1; e = e << 30 | (e >> 2);
                b += (c << 5 | (c >> 27)) + ((d & e) | (~d & a)) + x[3] + Y1; d = d << 30 | (d >> 2);
                a += (b << 5 | (b >> 27)) + ((c & d) | (~c & e)) + x[4] + Y1; c = c << 30 | (c >> 2); x += 5;
            }

            //
            // round 2
            //
            for (i = 0; i < 4; i++)
            {
                // E = rotateLeft(A, 5) + H(B, C, D) + E + X[idx++] + Y2
                // B = rotateLeft(B, 30)
                e += (a << 5 | (a >> 27)) + (b ^ c ^ d) + x[0] + Y2; b = b << 30 | (b >> 2);
                d += (e << 5 | (e >> 27)) + (a ^ b ^ c) + x[1] + Y2; a = a << 30 | (a >> 2);
                c += (d << 5 | (d >> 27)) + (e ^ a ^ b) + x[2] + Y2; e = e << 30 | (e >> 2);
                b += (c << 5 | (c >> 27)) + (d ^ e ^ a) + x[3] + Y2; d = d << 30 | (d >> 2);
                a += (b << 5 | (b >> 27)) + (c ^ d ^ e) + x[4] + Y2; c = c << 30 | (c >> 2); x += 5;
            }

            //
            // round 3
            //
            for (i = 0; i < 4; i++)
            {
                // E = rotateLeft(A, 5) + G(B, C, D) + E + X[idx++] + Y3
                // B = rotateLeft(B, 30)
                e += (a << 5 | (a >> 27)) + ((b & c) | (b & d) | (c & d)) + x[0] + Y3; b = b << 30 | (b >> 2);
                d += (e << 5 | (e >> 27)) + ((a & b) | (a & c) | (b & c)) + x[1] + Y3; a = a << 30 | (a >> 2);
                c += (d << 5 | (d >> 27)) + ((e & a) | (e & b) | (a & b)) + x[2] + Y3; e = e << 30 | (e >> 2);
                b += (c << 5 | (c >> 27)) + ((d & e) | (d & a) | (e & a)) + x[3] + Y3; d = d << 30 | (d >> 2);
                a += (b << 5 | (b >> 27)) + ((c & d) | (c & e) | (d & e)) + x[4] + Y3; c = c << 30 | (c >> 2); x += 5;
            }

            //
            // round 4
            //
            for (i = 0; i < 4; i++)
            {
                // E = rotateLeft(A, 5) + H(B, C, D) + E + X[idx++] + Y4
                // B = rotateLeft(B, 30)
                e += (a << 5 | (a >> 27)) + (b ^ c ^ d) + x[0] + Y4; b = b << 30 | (b >> 2);
                d += (e << 5 | (e >> 27)) + (a ^ b ^ c) + x[1] + Y4; a = a << 30 | (a >> 2);
                c += (d << 5 | (d >> 27)) + (e ^ a ^ b) + x[2] + Y4; e = e << 30 | (e >> 2);
                b += (c << 5 | (c >> 27)) + (d ^ e ^ a) + x[3] + Y4; d = d << 30 | (d >> 2);
                a += (b << 5 | (b >> 27)) + (c ^ d ^ e) + x[4] + Y4; c = c << 30 | (c >> 2); x += 5;
            }

            hash[0] += a;
            hash[1] += b;
            hash[2] += c;
            hash[3] += d;
            hash[4] += e;
        }

        static unsafe void SwapEndianSha(ulong* src, ulong* dst)
        {
            ulong value;
            value = src[0]; dst[0] = ((0xFF000000FF000000 & value) >> 24) | ((0x00FF000000FF0000 & value) >> 8) | ((0x0000FF000000FF00 & value) << 8) | ((0x000000FF000000FF & value) << 24);
            value = src[1]; dst[1] = ((0xFF000000FF000000 & value) >> 24) | ((0x00FF000000FF0000 & value) >> 8) | ((0x0000FF000000FF00 & value) << 8) | ((0x000000FF000000FF & value) << 24);
            value = src[2]; dst[2] = ((0xFF000000FF000000 & value) >> 24) | ((0x00FF000000FF0000 & value) >> 8) | ((0x0000FF000000FF00 & value) << 8) | ((0x000000FF000000FF & value) << 24);
            value = src[3]; dst[3] = ((0xFF000000FF000000 & value) >> 24) | ((0x00FF000000FF0000 & value) >> 8) | ((0x0000FF000000FF00 & value) << 8) | ((0x000000FF000000FF & value) << 24);
            value = src[4]; dst[4] = ((0xFF000000FF000000 & value) >> 24) | ((0x00FF000000FF0000 & value) >> 8) | ((0x0000FF000000FF00 & value) << 8) | ((0x000000FF000000FF & value) << 24);
            value = src[5]; dst[5] = ((0xFF000000FF000000 & value) >> 24) | ((0x00FF000000FF0000 & value) >> 8) | ((0x0000FF000000FF00 & value) << 8) | ((0x000000FF000000FF & value) << 24);
            value = src[6]; dst[6] = ((0xFF000000FF000000 & value) >> 24) | ((0x00FF000000FF0000 & value) >> 8) | ((0x0000FF000000FF00 & value) << 8) | ((0x000000FF000000FF & value) << 24);
            value = src[7]; dst[7] = ((0xFF000000FF000000 & value) >> 24) | ((0x00FF000000FF0000 & value) >> 8) | ((0x0000FF000000FF00 & value) << 8) | ((0x000000FF000000FF & value) << 24);
        }
    }
}
