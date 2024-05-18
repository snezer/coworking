<script setup lang="ts">

import {storeToRefs} from "pinia";
import {useEditorStore} from "../../store/useEditorStore.ts";
import {computed} from "vue";
import HomeElement from "./HomeElement.vue";

const { homeElements, selectFloorId } = storeToRefs(useEditorStore())

const homeElementsByFloor = computed(() => {
  return homeElements.value.filter(element =>{
    return element.level===selectFloorId.value
  } )
})
</script>

<template>
  <g>
    <HomeElement v-for="element in homeElementsByFloor"
                  :data="element"
                  :key="element?.id"
    />
  </g>
</template>

<style scoped>

</style>