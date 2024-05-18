<script setup>
import {useEditorStore} from "../../store/useEditorStore.ts";
import {storeToRefs} from "pinia";
import {defineProps} from 'vue'
import Room from "./Room.vue";
import Wall from "./Wall.vue";
const props = defineProps({
  data: {
    type: Object
  }
})

const editorStore = useEditorStore()
const {selectHomeElement, modeEditor} = storeToRefs(editorStore)

const select = (e)=>{
  e.preventDefault();
  if (modeEditor.value=='draw'){
    return;
  }
  if (modeEditor.value=='search'){
    editorStore.select_home_element_for_searche(props.data)
    e.stopPropagation();
    return;
  }
  if (props.data.newElement) {
    return;
  }
  if (!props.data.newElement) {

    editorStore.select_home_element(props.data)
    e.stopPropagation();
  }

}
</script>

<template>
  <g @click="select">
    <Room v-if="data?.type==='room'" :data="data"/>
    <Wall v-else  :data="data" />
  </g>
</template>

<style scoped>

</style>