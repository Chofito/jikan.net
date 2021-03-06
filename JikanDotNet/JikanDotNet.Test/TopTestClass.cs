﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace JikanDotNet.Tests
{
    public class TopTestClass
    {
		private readonly IJikan jikan;

		public TopTestClass()
		{
			jikan = new Jikan(true);
		}

		[Fact]
		public void ShouldParseTopAnime()
		{
			AnimeTop top = Task.Run(() => jikan.GetAnimeTop()).Result;

			Assert.NotNull(top);
		}

		[Fact]
		public void ShouldParseFMA()
		{
			AnimeTop top = Task.Run(() => jikan.GetAnimeTop()).Result;

			Assert.Equal("Fullmetal Alchemist: Brotherhood", top.Top.First().Title);
		}

		[Fact]
		public void ShouldParseFMAEpisodes()
		{
			AnimeTop top = Task.Run(() => jikan.GetAnimeTop()).Result;

			Assert.Equal(64, top.Top.First().Episodes);
		}

		[Fact]
		public void ShouldParseKimiNoNaWaType()
		{
			AnimeTop top = Task.Run(() => jikan.GetAnimeTop()).Result;

			Assert.Equal("Movie", top.Top.Skip(1).First().Type);
		}

		[Fact]
		public void ShouldParseKimiNoNaWaMovieList()
		{
			AnimeTop top = Task.Run(() => jikan.GetAnimeTop(1, TopAnimeExtension.TopMovies)).Result;

			Assert.Equal("Kimi no Na wa.", top.Top.First().Title);
		}

		[Fact]
		public void ShouldParseDeathNotePopularityList()
		{
			AnimeTop top = Task.Run(() => jikan.GetAnimeTop(1, TopAnimeExtension.TopPopularity)).Result;

			Assert.Equal("Death Note", top.Top.First().Title);
		}

		[Fact]
		public void ShouldParseLOGHOvaList()
		{
			AnimeTop top = Task.Run(() => jikan.GetAnimeTop(1, TopAnimeExtension.TopOva)).Result;

			Assert.Equal("Ginga Eiyuu Densetsu", top.Top.First().Title);
		}

		[Fact]
		public void ShouldParseLOGHOAiringStartvaList()
		{
			AnimeTop top = Task.Run(() => jikan.GetAnimeTop(1, TopAnimeExtension.TopOva)).Result;

			Assert.Equal("Jan 1988", top.Top.First().AiringStart);
		}

		[Fact]
		public void ShouldParseAnimeSecondPage()
		{
			AnimeTop top = Task.Run(() => jikan.GetAnimeTop(2)).Result;

			Assert.Contains("Ping Pong The Animation", top.Top.Select(x => x.Title));
			Assert.Contains("Yojouhan Shinwa Taikei", top.Top.Select(x => x.Title));
		}


		[Fact]
		public void ShouldParseTopManga()
		{
			MangaTop top = Task.Run(() => jikan.GetMangaTop()).Result;

			Assert.NotNull(top);
		}

		[Fact]
		public void ShouldParseBerserk()
		{
			MangaTop top = Task.Run(() => jikan.GetMangaTop()).Result;

			Assert.Equal("Berserk", top.Top.First().Title);
		}

		[Fact]
		public void ShouldParseBerserkStartDate()
		{
			MangaTop top = Task.Run(() => jikan.GetMangaTop()).Result;

			Assert.Equal("Aug 1989", top.Top.First().PublishingStart);
		}

		[Fact]
		public void ShouldParseHakoMari()
		{
			MangaTop top = Task.Run(() => jikan.GetMangaTop(1, TopMangaExtension.TopNovel)).Result;

			Assert.Equal("Utsuro no Hako to Zero no Maria", top.Top.First().Title);
		}

		[Fact]
		public void ShouldParseNarutoPopularity()
		{
			MangaTop top = Task.Run(() => jikan.GetMangaTop(1, TopMangaExtension.TopPopularity)).Result;

			Assert.Equal("Naruto", top.Top.First().Title);
		}

		[Fact]
		public void ShouldParseNarutoTypePopularity()
		{
			MangaTop top = Task.Run(() => jikan.GetMangaTop(1, TopMangaExtension.TopPopularity)).Result;

			Assert.Equal("Manga", top.Top.First().Type);
		}
	}
}
