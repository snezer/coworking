<script setup lang="ts">
import {defineProps, computed} from 'vue'

import {useEditorStore} from "../../../store/useEditorStore.ts";
import {storeToRefs} from "pinia";

const props = defineProps({
  data: {
    type: Object
  }
})

const editorStore = useEditorStore()

const {modeEditor, selectedNode} = storeToRefs(editorStore)

const select = function (e){
  e.preventDefault();
  if (modeEditor.value =='draw'){
    return;
  }
  if (props.data.newElement) {
    return;
  }
  if (!props.data.newElement) {

    editorStore.select_node(props.data)
    e.stopPropagation();
  }

}

const iconUrl = computed(()=>{
  let path = ''
  switch (props.data.type) {
    case 'door' : path = 'door.svg'
      break;
    case 'stair' : path = 'stair.svg'
      break;
    case 'elevator' : path = 'elevator.svg'
      break;
  }
  return path
})
</script>

<template>
  <g @click="select">
    <circle :cx="data?.position.x"
            :cy="data?.position.y"
            r="10"
            opacity="0"></circle>
    <foreignObject
        :x="data?.position.x-10"
        :y="data?.position.y-10"
        height="20" width="20">
      <img :src="require('@/assets/icon/'+iconUrl)">
    </foreignObject>
  </g>
</template>

<style scoped>

</style>