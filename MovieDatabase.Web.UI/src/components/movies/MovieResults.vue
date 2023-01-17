<script lang="ts">
import { useMovieStore } from "@/stores/movies";
import { storeToRefs } from "pinia";
import { defineComponent } from "vue";

export default defineComponent({
  setup(props: any, context) {
    const { loading, movies, error } = storeToRefs(useMovieStore());
    const store = useMovieStore();

    store.search("Rogue");

    return () =>
      context?.slots?.default?.({
        loading: loading.value,
        movies: movies.value,
        error: error.value,
      });
  },
});
</script>
