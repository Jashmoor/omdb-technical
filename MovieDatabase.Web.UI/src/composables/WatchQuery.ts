import { useMovieStore } from "@/stores/movies";
import { storeToRefs } from "pinia";
import { watch, ref, toRef, computed } from "vue";
import { useRoute, useRouter } from "vue-router";

export const useWatchQuery = function () {
  const route = useRoute();
  const term = computed(() => route.params.term as string);
  const { type } = storeToRefs(useMovieStore());
  const router = useRouter();
  const routerKey = computed(() => `${type.value}-${term.value}`);
  const title = ref((term.value as string) || "");
  const update = async () => {
    await router.push({
      name: "home",
      params: {
        term: title.value,
      },
    });
  };

  return {
    routerKey,
    term,
    title,
    update,
  };
};
