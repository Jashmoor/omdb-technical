import { defineStore } from "pinia";

export type SearchType = "movie" | "series" | "episode";

export const useMovieStore = defineStore("movies", {
  state: () => ({
    loading: false,
    error: null as string | null,
    movies: [] as any[],
    movie: null as any,
    type: "movie" as SearchType,
    types: ["movie", "episode", "series"] as SearchType[],
    totalResults: null as number | null,
    term: null as string | null,
  }),
  actions: {
    async search(term: string | null, type: string | null) {
      try {
        this.loading = true;
        this.error = null;
        this.movies = [];
        term ??= "Game";

        const response = await fetch(
          `/search?term=${term}&type=${type || null}`
        );
        const { search, totalResults } = await response.json();

        if (!search) {
          throw new Error("No Data Found");
        }
        [this.movies, this.totalResults] = [search, totalResults];
      } catch (err: any) {
        this.error = err?.message || "Request Error";
      } finally {
        this.loading = false;
      }
    },
    async getDetails(title: string) {
      console.log(title);
      try {
        this.loading = true;
        this.error = null;
        this.movie = null;
        const response = await fetch(`/detail?title=${title}`);
        const movie = await response.json();
        console.log(movie);
        if (!movie) {
          throw new Error("No Data Found");
        }
        [this.movie] = [movie];
      } catch (err: any) {
        this.error = err?.message || "Request Error";
      } finally {
        this.loading = false;
      }
    },
  },
});
