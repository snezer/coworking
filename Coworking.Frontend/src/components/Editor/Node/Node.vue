<script setup lang="ts">
import {defineProps, computed, defineAsyncComponent} from 'vue'

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
    case 'audio2' : path = defineAsyncComponent(() => import((`../../../assets/icon/audio2.svg`)))
      break;
    case 'audioall' : path = defineAsyncComponent(() => import((`../../../assets/icon/audioall.svg`)))
      break;
    case 'chair' : path = defineAsyncComponent(() => import((`../../../assets/icon/chair.svg`)))
      break;
    case 'coffeemachine' : path = defineAsyncComponent(() => import((`../../../assets/icon/coffeemachine.svg`)))
      break;
    case 'computer' : path = defineAsyncComponent(() => import((`../../../assets/icon/computer.svg`)))
      break;
    case 'cooler' : path = defineAsyncComponent(() => import((`../../../assets/icon/cooler.svg`)))
      break;
    case 'fridge' : path = defineAsyncComponent(() => import((`../../../assets/icon/fridge.svg`)))
      break;
    case 'printer' : path = defineAsyncComponent(() => import((`../../../assets/icon/printer.svg`)))
      break;
    case 'reception' : path = defineAsyncComponent(() => import((`../../../assets/icon/reception.svg`)))
      break;
    case 'round' : path = defineAsyncComponent(() => import((`../../../assets/icon/round.svg`)))
      break;
    case 'teaport1' : path = defineAsyncComponent(() => import((`../../../assets/icon/teaport1.svg`)))
      break;
    case 'toilet' : path = defineAsyncComponent(() => import((`../../../assets/icon/toilet.svg`)))
      break;
    case 'table' : path = defineAsyncComponent(() => import((`../../../assets/icon/table.svg`)))
      break;
    case 'tv' : path = defineAsyncComponent(() => import((`../../../assets/icon/tv.svg`)))
      break;


  }
  return path
})

</script>

<template>
  {{iconUrl}}
  <g @click="select">
    <circle :cx="data?.position.x"
            :cy="data?.position.y"
            r="40"
            opacity="0">    </circle>
    <foreignObject
        :x="data?.position.x"
        :y="data?.position.y"
        height="40" width="40">  <!--  40 это скейл из модели ноды-->
<!--      <component :is="iconUrl" style="height: 100%; width: 100%" />-->
      <component :is="iconUrl" />
    </foreignObject>

  </g>
</template>

<style scoped>

</style>