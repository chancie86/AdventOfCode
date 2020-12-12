﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Day_11
{
    public static class TestData
    {
        public static string[] PracticeData => new[]
        {
            "L.LL.LL.LL",
            "LLLLLLL.LL",
            "L.L.L..L..",
            "LLLL.LL.LL",
            "L.LL.LL.LL",
            "L.LLLLL.LL",
            "..L.L.....",
            "LLLLLLLLLL",
            "L.LLLLLL.L",
            "L.LLLLL.LL"
        };

        public static string[] Data => new[]
        {
            "LLLLLLL.LLLLLLLLLLLL.LL.L.LLLLLLLLLLLLLLLLLL.LLLLL.LLLLLLL.LLLLLLLLL.LLLL.LLLLL.LLLLLLLLLLLLL",
            "LLLLLLL.LLLLLLLLLLLL.LLL..LLLLLLLLLLLLLLLLLLLLLLL..LLLL.LLLLLLLLLLLLLLLLLLLLLLL.LLLLLLL.LLLLL",
            "LLLLLLLLLLLLLL.LLLLLLLLLL.LLLLLLLL.LLLLLLLLL.LLLLL.LLLLLLL.LLLLLLLLL.LLLL.LLLLLLLLLLLLLLLLLLL",
            "LLLLLLLLLLLLLL.LLLLL.LLLLLLLLLLLLLLLLLL.LLLL.LLLLLLLLLLL.LLLLLLLLLLLLLLLL.LLLLL.LLLLLLLL.LLLL",
            "LLLLLLL.LLLLLL.LLLLL.LLLLLLLLLLLLLLLLLLLLLLL.LLLLL.LLLLLLL.LLLLLLLLLLLLLL.LLLLL.LLLLLLL.LLLLL",
            "LLLLLLL.LLLLLL.L.LLLLLLLL.L.LLLLLL.LLLLLL.LL.LLLLL.LLLLLLLLLLLLLLLLL.LLLL.LLLLL.LLLLLLLLLLLLL",
            ".L.....L...L.....LL..L...LLL.L.LL..LLL..LL.LLL...LLLL..L......L..........L...L..LL..LLL.L...L",
            "LLLLLLLLLLLLLLLLLLLL.LLLLLLLLLLLLLLLLLLL.LLLLLLLLL.LLLLLLL.LLLLLLLLL.LLLL.LLLLL.LLLLLLL.LLLLL",
            "LLLLLLL.LLLLLL.LLLLL.L.LLLLLLLLLLL.LLLLLLLLL.LLLLLLLLLLLLL.LLLLLLLLL.LLLLLLL.LL.LLLLLLLLLLLLL",
            "LLLL.LL.LLLLLL.LLLL.LLLLL.LLLLL.LLLLLLLLLLLL.LLLLLLLLLLLLL.LLLLLLLLL.LL.LLLLL.LLLLLLLLL.LLLL.",
            "LLLLLLL.LLLLLL.LLLLL..LLL.LLLLLL.L.LLLLLLLLL.LLLL..LLLLLLL.L.L.LLLLL.LLLLLLLLLL.LLLLLLLLLLLLL",
            "LLL.LLL.LLLLLLLLLL.L.LLLL..LLLLLLLLLL.LL.LL.LLLLLL.LLLLL.LLLLLLLLLLL.LLLL.LLLLL.LLLLLLL.LLLLL",
            "LLLLLLL.LLLLLLLLLLLLLLLLLLLLLLL.LLLLLLLLLL.L.LLLLL.LLLLLLL.LL.LLLLLLLLLLL.LLLLL.LLLLLLLLLLLL.",
            "LLLLLLL.LLLLLLLLLLLLLLLLL.LLLLLLLLLLLLLLLLLL.LLLLL.LLLLLLLLLLLLLLLLLLLLLL.LLLLL.LLLLLLL.LLLLL",
            "L...L..LLL.....L.LL..L.LLLL....LLLL.....L.L.LLL..L.L...LL.LL....L..LLLL..L..L.LL...L.L.....L.",
            "LLLLLLL.LLLLLLLLLLLLLLLLL.LLLLLLLL.LLLLLLLLL.LLL.L.LLLLLLLLLLLLLLLLL.LLLL.LLLLL.LLLLLLL.LLLLL",
            "LLLLLLL.LLLLLL.LLLLL.LLLL.LLLLLLLL.LLLLLLLLL.LLLLLLLLLLLLLLLLLLL.LLL.LLLLLLL.LLLLLLLLLL.LLLLL",
            "LLLLLLL.LLLLLLLLLLLL.LLLL.LLLL.LLL.LLLLLLLLLLLLLLLLLLL.LLLLLLLLLLLLL.L.LL.LLLLL.LLLLLLLLLLLLL",
            "LLLLLLL..LLLLLLLLLLL.LLLLLLLLLLLLL.LLLLLLLLLLLLLLL.LLLLLLL.LLLLLLLLLLLLLL.LLLLL.LLLLLLLLLLLLL",
            ".........LL..LL..LL..LL.....L..L..LL.............L...L....LLLL...LL...LLL..L...LLL.....L....L",
            "LLLLLLLLLLLLLLLLLLLL.LLLLLLLLLLLLLLLLLLLLLLL.LLLLLLLLLLLLLLLLLLLLLLL.LLLL.LLLLL..LLLLLL.L.LLL",
            "LLLLLLLLLLLLLL.LLLLLLLLLL.LLLLLLLL.LLLLLLLLLLLLLLL.LLLLLLL.LLLLLLLLLLLLLLLLLLLL.LLLLLLLLLLLLL",
            "LLLLLLL.LL.LLL.LLLLL.LLLL.LLLLLLLL.LLLLLLLLLLLLLLL.LLLLLLL.LLLLLLLLL.LLLLLLLLL.LLL.LLLLLLLLLL",
            "LLLLLLL.LLLLLLLLLLL.LLLLLLLLLLLLLL.LLLLLLLLL.LLLLLLLLLLLLL.LLLLLLLLL.LLLL.LL.LL..LLLLLLLLLLLL",
            "LLLLLLL.LLLLLLLLLLLL.LLLL.LLLLLLLLLL.LLLLLLL.LLLLL.LLLLLLL.LLLLLLLLL.LLLL.LLLLL.LLLLLLL.LLLLL",
            "LLLLLLLLLLL.L.LLLLLL.LLLLLLLLLLLLLLLLLLLLLLL.LLLLLLLLLLLLL.LLLLLLLLL.LLLLLLLLLLLLLLLLLLLLLLLL",
            "...L.L..L.L.L....L....L.LLL.L.L.L..L..L...L....L......L.......L..L.L.L..L..LL...L....L....LL.",
            "LLLLLLL.LLLLLL.LLLLLLLLLLLLLLLLLLLLLLLLLLLLL.LLLLLLLLLLLLL.LLLLLLLLL.L.LL.LL.LL.LLLLLLLLLLLLL",
            "LLLLLLL.LLLLLL.LLLLL.LLLL.LLLLLLLL.LLLLLLL.L.LLLLL.LLLLLLL.LLLLLLLLL.LLLL.LLLLL.LLLLLLL.LLLLL",
            "LLLLLLLLLLLLLL.LLLLL.LLLL.LLLLLLLLLLLLLLLLLLLLLLLL.LLLLLLL.LLLLLLLLL..LLL..LLLL.LLLL.LL.LLLLL",
            "LLLLLLLLLLLLLLLLLLLL.LLLLLLL.LLLLL.LLLLLLLLL.LLLLL.L.LLLL.LLLLLLLLLLLLLLLLLLLLLLLLLLLLL.LLLLL",
            "LLLLLLLLLLLLLL.LLLLLLLLLL.LLLLLLLLLLLLLLLLLL.LLLLL.LLLLLLL.LLLLLLLLL.LLLL.LLLLLLLLLLLLL..LLLL",
            "LLLLLLL.LLLLLLLLLLLL.LLLLLLLLLLLLL.LLLLLLLLL.LL.LLLLLLLLLL.LLLLLLLLL.LLLLLLLLLL.LLLLLLL.LLLLL",
            "..LLLLL...LL...L..L.....L.LL.L....L.L..LL.L......L.L.L..L...L.L..L..L..L.LL..L.L.L..L.....L..",
            "LLLLLLL.LLLLLL.LLL.L.LLLL.LLLLLLLLLLLLLLLLLL.LLLLL.LLLLLLLLLLLLLLLLLLLLLL.LLLLL.LLLLLLL.LLLLL",
            "LLLLLLL.LLL.LL.LLLLL.LLLL.LLLLLLLL.LLLLLL.LL.LLLL..LLLLLL.LLLLLLLLLL.LLLL..LLLL.LLLLLLL.LLLLL",
            "LLLLLLLLLLLLLL.LLLLL.LLLL.LLLLLLLL.LLLLLLLLL.LLLLL.LLLLLLL.LLLLLLLLL.LLLLLLLLLL.LLLLLLL.LLLLL",
            ".LLLLLL.LLLLLL.LLLLL.LLLLLLLLL.LLL.LLLLLLL.L.LLLLLLLLLLLLLLLL.LLLLLL.LLLL.LLLLL.LLLLLLL.LLLLL",
            "LLLLLLL.LLLLLL.LLLLLLLLLL.LLLLLLLL.LLLLLLLLL.LLLL.LLLLLLLL.LLLLLLLLL.LLLL.LLLLL.LLLLLLLLLLLLL",
            "LLLLLLL.LLL.LL.LLLLLLLLLL.LLLLLLLL.LLLLLLLLL.LLLLL.LLLL.LL.LL.LLLLLLLLLLLLLL.LL.LLLL.LL.LLLL.",
            "LLLLLLL.LLLLLL.LLLLLLLLLL.L..LLLLLLLLLLLLLLL.LLLLLLLLLLLL.LLLLLLLLLLLLLLL.LLLLL.LLLLLLL.LLLLL",
            "LL......LLL...L.LL...LL..LLLL.L..L.........L..L.....L..L......L..L...LLL.....LL.......LL.....",
            "LLLLLLL.LLLLLL.LLLLL.L.LL.LLLLLLLL.LLLL.LLLLL.L.LLLLLLLLLL.LLLLLLLLL.LLLLLLLLL..LLLLLLLLLLLLL",
            "LLLLLLL.L.LLLL.LLLLL.LLLLLLLLLL.LLLLLLLLLLLLLLLLLLLLLLLLLL.LLLLLLLLL.LLLL.LL.LL.LLLLLLLLLLLLL",
            "LLLLLLL.LLLLLL.LLLLLLLLLL..LLLLLLLLLLLLLLLLLLLLLLL.L.LLLLL.LLLLLLLLL.LLLLLLLLLLLLLLLLLLLLLLLL",
            "LLLLLLL.LLLL.LLLLLLLLLLLLLLLLLLLLLLLLLLLLLLL.LLLLL.LLLLLLL.LLLLLLLLL.LLLL.LLLLL.L.LLLLLLLLLLL",
            "LLLLLLL.LLLLLL.LLLLL.LLLL.LLL.LLLLLLLLLLLLLL.LLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLL.LLLLLLLLLLLLL",
            "LLLLLLL.LLLLLL.LLLLL.LLLL.LLLLLLLLL.LLLLLLLLLLLLLL.LLLLLLL.LLLLLLLLL.LLL.LLLLLLLLLLLLLLLLLLLL",
            "LLLLLLL.LLLLLL.LLL.L.LLLL.LLLLLLLL.LLLLLLLLL.LLLLLLLLLLLLL.LLLLLLLLL.LLLL.LLLLL.LLLLLLLLLLLLL",
            "L....L.L..L.L....L..L.L...L.....L..LL...L.L.L.L.LL..L....LL..LL....L.L.......LLL..LLL...LL..L",
            "LLLLLLLLLLLLLLLLLLLLLLLLL.LLLLLLLL.LLLLLLL.LLLLLLLLLLLLLL..LLLLLLLLL.LLLL..LLLL.LLLLLLLLLLLLL",
            "LLLLLLLLLLLLLL.LLLLL.LLLL.LLLLLLLLLLLLLLLLLL.LLLLL.LLLLLLL.LLLLLLLLLL.LLLLLLLLL.LLLLLLL.LLLLL",
            "LLLLLLL.LLLLL..LLLLL.LLLLLLLLLLLLL.LLLLLL.LL..LLLLLLLLLLLLLLLLLLLLLL.LLLL.LLLLL.LLLLLLLLL.LLL",
            "L.L.LLLLLLLLLL.LLLLL.LLLL.LLLLL.LL.LLLLLLLLL.LLLLL.LLLLLLL.LLLLL.LLL.LLLL.LLLLLLLLLLLLLLLLLLL",
            "LLLLLLL.LLLLLL.LLLLLLLLLL.LLLLLLLLLLLLLLLLLLLLLLLLL.LLLLLL.LLLLLLLLLLLLLL.LLLLL.LLLLLLL.LLLLL",
            "LLLLLLL.LLLLLLLLLLLL.LLLL.LLLLLLLL.LLLLLLLLL.LLLLL.LLLLLLL.LLLLLLLLL.LLLL.LLLLLLLLLLLLL.LLLLL",
            "LLLLLLLLLLLLLL.LLLLL.LLLL.LLLLLLLL.LLLLLLLLL.LLLLL.LLLLLLL.LLLLLLLLL.LLLL.LLLLL.LLLLLLL.LLLLL",
            "LLLLLLL.L.LLLLLLLLLL.LLLLL.LLLLLLLLLLLLLLLLL.LLLLL.LLLLLLL.LLLL.LLLL.LLLL.LLLLLLLLLLLLLLLLLL.",
            "LL.L.LLLLLLLLL.LLLLLLLLLL.LLLLLLLLLLLLLLLLLL.LLLLL.LLLLLLL.LLLLLLLLL.LLLL.LLLLLLLLLLLLL.LLLLL",
            "...L..L..L..L....LLL..L.LL....L........L.......L.L.LL.L........L...LLLL....LL.......L.LL..L.L",
            "LLLLLLLLLLLLLL.LLLLLLLLLL.LLLLLLLLLLLLLLLLLL.LLLLLLLLLLLLL.LLLLLLLLLLLLLLLLLLLL.LLLLLLLLLLLLL",
            "LLLLLLL.LLLLLL.LL.LL.LLLLLLLLLL.LL.LLLLLLLLL.LLLLL.LLL..LLLLLLLLLLLL.LLLL..LL.L.LLLLLLL.LLLLL",
            "LLLLLLL.LLLLLLLLLLLL.LLLL.LLLLLLLL.LLLLLLL.L.LL.LL.LLLLLLL.LLLLLLLLLL.LLL.LLLLL.LLLLLLL.LLLLL",
            "LLLLLLLLLLL.LL.L.LLL.LLLL.LLLLLLL..LLLLLLLLL.LLLLLL.LLLLLLLLLLLLLLLL.LLLL..LLLLLLLLLLLL.LLLLL",
            "LLLLLLLLLLLLLLLLLLLL.LLLLLLLLLLLLLLLLLLLLLLLLLLLLL.LLLLLLL.LLLLLLLLLLLLLLLLLLLL.LLLLL.L.LLLLL",
            "LLLLLLL.LLLLLL.LLLLLLLLLL.LLLLLLLL.L.LLLLLLL.LLLLLLLLLLLLL.LLLLLLLLL.LLLL.LLLLL.LLLLLLLLLLLLL",
            "LLLLLLLLLLLLLL.LLLLL.LLLL.LLLLLLLL.LLLLLLLLLLLLLLL.LLLLLLLLLLLLLLLLL.LLLL.L.LLL.LLLLLLL..LLLL",
            "LLLLLLL.LLLLLL.LLLLL.LLLL.LLLLLLLLLLLLLLLLLLLLLLLL.LLLLLLL.LLLLLLLLL.L.LL.L.LLL.LLLLLLL.LLLL.",
            "....LLLL.L..L....LL..L.....LL..........LL.....L.L..LL.LL......L.L.L.L....L.LL.L.L..L......L..",
            "LLLLLLLLLLLLLL.LLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLL.LLLLLLLLLLLLLLLLLLLLLL.LLLLLLLLLLL.LLLLLLL",
            "LLLLLLLLLLL.LLLLLLLL.LLLL.LLLLLLLL.LLL.LLLLL.LLLL..LLLLLLLLLLLLLLLLL.LLLL.LLLLL..LLLLLL.LLLLL",
            "LLLLLLLLLLLLLL.LLLLL.LLLL.LLLLLLLLLLLLLLL.LL.LLLLL.LLLLLLLLLLLLLLLLLLLLLL.LLLLL.LLLLLLL.LL.LL",
            "LLLLLLL.LLLLLL.LLLLL.LLLL.LLLLLLLL.LLLLLLLLLLLLLLL.LLLLLLL.LLLLLLLLL.LLLL.LLLLLLL.LLLLLLLLLL.",
            "LLLLLLLLLLLLLL.LLLLLLLLLL.LLLLLLLL..LLLLLL.LLLLLLL.LL.LLLLLLLLLLLLLLLLLLLLLLLLL.L.LLLLL..LLLL",
            "LLL.LLLLLLLLLLLLLLLLLLLLL.LLLLLLLLLLLLLLLLLLLLL.LL.LLLLLLL.LLLLLLL.L.LLLL.LLLLL.LLLLLLL.LLLLL",
            "LLLLLLLLLLLLLL.LLLLL.LLLL.LLLLLLLL.LLLL.LLLL.LLLLL.LLLL.LLLLLLLLLLLL.LLLLLLLLLL.LLLLLLL.LLLLL",
            "LLLLLL..LLLLLLLLLL.L.LLLL.LLLLLLLLLLLLLLLLLLLLLLLL.LLLLLLL.LLLLLLLLL.LLLLLLLLLL.LLLLLLL.L.LLL",
            "LLLLLLLLLL.LLLLLLLLL.LL.L.LLLLLLLL.LLLLLLLLL.LLLLLLLLLLLLL.LLLLLLLLL.LLLL.LLLLL.LLL.LLL.LLLLL",
            "L.L...L....LL.L....LL..L...L...LL.L.............LLLLL..LL........LLL.L....L.L...L.L...LLL.LL.",
            "LLLLLLL.LLLLLL.LLLLLLLLLL.LLLLLLLL.LLLLLLLLL.LLLLL.LLLLLLL.LLLLLLLLL.LLLL.LLLLLL.LLLLLL.LLLLL",
            "LL.LLLL.LLLLLLLLLLLL.LLLLLLLLLLLLLLLLLL.LLLL.LLLLL.LLLLLLL.L.LLL.LLLLLLLLLLLLLLLLLLLLLLLLLLLL",
            "LLLLLLL.LLLLLL.LLLLL.LLLLLLLLLLLLL.LLLLLLLLL.LLLLL.LLLLLLLLLLLLLLLLL.LLLL.LLLLL.LLLLLLLLLLLLL",
            "LLLLLLL.LLLLLL.LLLLLLLLLL.LLLLLLLLLLLLLLLLLLLLLLLL.LLLLLLLLLLLLLLLLL.LLLL.LLL.LLLLLLLLLLL.LLL",
            ".LLL..LL.L.LL.L...L.L..L...L....L.L................L....L.......L..L.....L...LLL....L....LL..",
            "LLLLL.LLLLLLLL.LLLLL.L.LL.LLLLLLLL.LLLLLLLLL..LLLLLLLLLLLL.LLLLLLLLL.LLLL.LLLLL.LLLLLLL.LLLLL",
            "LLLLLLL.LLLLLL.LLLLLLLLLL.LL.L.LLL.LLLLLL.LL.LLLLL.LLLLLLL.LLLLLLLLL.LLLL.LLL.LLLLLLLLL.LLLLL",
            "LLLLLLL.LLLLLL.LLLLL.LLLL.LLLLLLLLLL.L.LLLLL.LLLLLLLLLLLLLLLLLLLLLLL.LLLLLLLLLLLLLLLLLL.LLLLL",
            "LLLLLL..LLLLLLLLLLLLLLLLL.LLLLLLLL.L.LLL.LLL.LLLLL.LLLLLLLLLLLLLLLLL.LLLLLLLLLL.LLLLLLLLLLLLL",
            "LLLLLLL.LLLL.L.LLL.LLLLLLLLLLLLLLL.LLLLLLLLL.LLLLL.LLLLLLL.LLLLLLLLL.LLLL.LLLLL.LLLL.LLLLLLLL",
            "LLLLLLL.LLLLLLLLLLLL..LLL.LLLLLLLL..LLLLLLLLLLLLLL.LLLLLLLLLLL.LLLLLLL.LLLLLLLL.LLLLLLL.LLLLL"
        };
    }
}
