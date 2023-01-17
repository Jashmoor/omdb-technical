<script setup lang="ts">
import { RouterView } from "vue-router";
import { useWatchQuery } from "./composables/WatchQuery";
const query = useWatchQuery();
</script>

<template>
  <RouterView :key="query.routerKey.value" />
</template>

<style scoped></style>
