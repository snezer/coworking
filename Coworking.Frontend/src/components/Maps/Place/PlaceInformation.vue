<script setup lang="ts">


import {storeToRefs} from "pinia";
import {useMapStore} from "../../../store/useMapStore.ts";

const {activePoint} =storeToRefs(useMapStore())
</script>

<template>
  <div class="place-information">
    {{activePoint}}
  </div>
</template>

<style scoped>
.place-information{
  width: 100%;
  height: 100%;
  background: white;
  border-radius: 1rem 0 0 1rem;
}
</style>
