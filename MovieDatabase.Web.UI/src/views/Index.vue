<script setup lang="ts">
import { useMovieStore } from "@/stores/movies";
import { onMounted } from "vue";
import MovieResults from "../components/movies/MovieResults.vue";
import MovieCard from "../components/movies/MovieCard.vue";
import LoadingSpinner from "../components/utils/LoadingSpinner.vue";
import { watch } from "vue";
import { useWatchQuery } from "@/composables/WatchQuery";
import ListTransition from "@/components/transitions/ListTransition.vue";
import { storeToRefs } from "pinia";
import MovieDetails from "@/components/movies/MovieDetails.vue";
import FadeTransition from "@/components/transitions/FadeTransition.vue";

const store = useMovieStore();
const { type, types, movie } = storeToRefs(useMovieStore());
const { term: $SEARCH_TERM, update, title } = useWatchQuery();

watch(
  () => $SEARCH_TERM.value,
  async () =>
    await store.search($SEARCH_TERM.value as string | null, type.value)
);

onMounted(async () => {
  await store.search($SEARCH_TERM.value as string | null, type.value);
});
</script>

<template>
  <main class="h-screen w-screen bg-[#323232] text-white overflow-hidden">
    <form
      @submit.stop.prevent="update"
      class="h-1/3 sm:h-1/3 flex flex-col sm:block w-[65%] m-auto pt-8 md:pt-16"
    >
      <div class="relative z-0 w-full mb-6 group">
        <input
          type="title"
          name="term"
          v-model="title"
          id="floating_email"
          class="block py-2.5 px-0 w-full text-sm text-gray-900 bg-transparent border-0 border-b-2 border-gray-300 appearance-none dark:text-white dark:border-gray-600 dark:focus:border-blue-500 focus:outline-none focus:ring-0 focus:border-blue-600 peer"
          placeholder=" "
          required
        />
        <label
          for="title"
          class="peer-focus:font-medium absolute text-sm text-gray-500 dark:text-gray-400 duration-300 transform -translate-y-6 scale-75 top-3 -z-10 origin-[0] peer-focus:left-0 peer-focus:text-blue-600 peer-focus:dark:text-blue-500 peer-placeholder-shown:scale-100 peer-placeholder-shown:translate-y-0 peer-focus:scale-75 peer-focus:-translate-y-6"
          >Movie Title</label
        >
      </div>
      <div class="flex flex-col w-full container m-auto mt-0">
        <ul
          class="items-center w-full text-sm font-medium text-gray-900 bg-[#323232] border border-gray-200 rounded-lg sm:flex"
        >
          <li
            v-for="(options, index) in types"
            :key="index"
            class="w-full border-b border-white sm:border-b-0 sm:border-r"
          >
            <div class="flex items-center pl-3">
              <input
                id="search-type"
                type="radio"
                :value="options"
                v-model="type"
                name="list-radio"
                class="w-4 h-4 text-white bg-gray-100 border-white focus:ring-[#323232] focus:ring-2"
              />
              <label
                for="search-type"
                class="w-full uppercase py-3 ml-2 text-sm font-medium text-gray-200"
                >{{ options }}
              </label>
            </div>
          </li>
        </ul>
        <button
          type="submit"
          class="text-white my-2 bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm w-full sm:w-auto px-5 py-2.5 text-center dark:bg-blue-600 dark:hover:bg-blue-700 dark:focus:ring-blue-800"
        >
          Submit
        </button>
      </div>
    </form>
    <MovieResults #="{ loading, error, movies }">
      <LoadingSpinner v-if="loading" />
      <div v-else class="gap-2 overflow-x-auto h-4/5">
        <div class="mx-auto max-w-2xl px-4 sm:px-6 lg:max-w-7xl lg:px-8">
          <ListTransition
            tag="div"
            class="grid grid-cols-1 gap-y-10 gap-x-6 sm:grid-cols-2 lg:grid-cols-3"
          >
            <MovieCard
              v-for="(movie, index) in movies"
              :key="index"
              :movie="movie"
              class="flex-none"
              @detail="store.getDetails"
            />
          </ListTransition>
        </div>
      </div>
    </MovieResults>
    <MovieDetails :movie="movie" />
  </main>
</template>

<style lang="scss">
.text-input {
  @apply relative w-full;

  label {
    @apply pointer-events-none absolute left-0 top-0 z-10 block origin-top-left translate-y-4 translate-x-5 select-none text-[#323232] font-semibold text-gray-600 transition-transform duration-150 ease-in-out;
  }

  input {
    @apply text-black font-bold relative z-0 block w-full rounded border-0 border-transparent bg-neutral-50 px-5 pt-[24px] pb-1.5;
    @apply focus:bg-[#f6fafd] focus:outline-none focus:ring-2;

    &::placeholder {
      @apply text-base text-[#61A6C8] opacity-50;
    }

    &:focus-within {
      ~ label {
        @apply translate-y-2 scale-[0.725] text-[#026496];
      }

      &::placeholder {
        @apply opacity-50;
      }
    }

    &:not(:placeholder-shown) ~ label {
      @apply translate-y-2 scale-[0.725];
    }

    &:focus {
      &::placeholder {
        @apply opacity-100;
      }
    }

    &:disabled {
      @apply bg-white;
    }
  }

  &_helper-text {
    @apply mt-1 text-xs text-neutral-600;

    &.-error {
      @apply px-5 font-semibold;
    }
  }

  &.-disabled {
    @apply opacity-50;
  }

  &.-error {
    label {
      @apply text-black;
    }

    input {
      @apply bg-[#fdf6f6] placeholder-[#C86161];

      &:not(:placeholder-shown) ~ label,
      &:focus-within {
        ~ label {
          @apply text-black;
        }
      }
    }
  }
}
</style>
