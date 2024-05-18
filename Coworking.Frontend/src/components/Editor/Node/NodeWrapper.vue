<script setup lang="ts">


import {useEditorStore} from "../../../store/useEditorStore.ts";
import {storeToRefs} from "pinia";
import {computed} from "vue";
import Node from "./Node.vue";

const editorStore = useEditorStore()

const {nodeElements, selectFloorId} = storeToRefs(editorStore)

const nodeElementsbyFloor = computed(() => {
  return nodeElements.value.filter(floor => floor.levelId === selectFloorId.value)
})
</script>

<template>
  node {{nodeElementsbyFloor}}
  <g>
    <Node
        v-for="node in nodeElementsbyFloor"
        :data="node"
        :key="node.id"
    />
    {{nodeElements}}
  </g>
</template>

<style scoped>

</style>