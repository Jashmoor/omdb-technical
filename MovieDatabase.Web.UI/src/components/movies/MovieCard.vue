<script setup lang="ts">
const { movie } = defineProps<{
  movie: any;
}>();

const emit = defineEmits<{
  (e: "detail", title: string): void;
}>();
</script>

<template>
  <article
    class="block m-auto relative cursor-pointer transition duration-200 ease-out md:hover:scale-105"
    @click="emit('detail', movie?.title)"
  >
    <img
      :src="movie?.poster"
      :alt="movie?.title"
      :title="movie?.title"
      class="rounded-sm object-cover md:rounded"
    />
  </article>
</template>
