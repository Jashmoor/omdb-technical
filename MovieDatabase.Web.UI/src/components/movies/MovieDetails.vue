<script setup lang="ts">
import { useMovieStore } from "@/stores/movies";
import { storeToRefs } from "pinia";
import { ref, watch } from "vue";
import FadeTransition from "../transitions/FadeTransition.vue";
const { movie } = storeToRefs(useMovieStore());

watch(
  () => movie.value,
  () => {
    if (isOpen.value === false) {
      isOpen.value = true;
    }
  }
);

const isOpen = ref(false);
</script>
<template>
  <div class="container mx-auto">
    <div class="flex justify-center">
      <button
        @click="isOpen = true"
        class="px-6 py-2 text-black bg-black rounded shadow"
        type="button"
      >
        Open Model
      </button>
      <FadeTransition>
        <div
          v-show="isOpen"
          class="absolute inset-0 flex items-center justify-center bg-gray-700 bg-opacity-50"
        >
          <div
            class="max-w-2xl p-6 bg-white rounded-md shadow-xl text-[#323232] text-center"
          >
            <img
              :src="movie?.poster"
              :alt="movie?.title"
              class="rounded-full w-96 h-96 object-cover m-auto"
            />
            <h3 class="text-2xl">{{ movie?.title }}</h3>
            <div class="mt-4">
              <p class="mb-4 text-lg">
                {{ movie?.rating }}
              </p>
              <p class="mb-4 text-lg">
                {{ movie?.genre }}
              </p>
              <p class="mb-4 text-sm">
                {{ movie?.plot }}
              </p>
              <p class="mb-4 text-sm font-bold">
                {{ movie?.year }}
              </p>
              <button
                @click="isOpen = false"
                class="px-6 py-2 text-blue-800 border border-blue-600 rounded"
              >
                Close
              </button>
            </div>
          </div>
        </div>
      </FadeTransition>
    </div>
  </div>
</template>
