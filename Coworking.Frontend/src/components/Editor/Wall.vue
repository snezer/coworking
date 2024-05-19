<script setup>
import {computed, defineProps} from 'vue'
import {useEditorStore} from "../../store/useEditorStore.ts";
import {storeToRefs} from "pinia";

const props = defineProps({
  data: {
    type: Object
  }
})

const editorStore = useEditorStore()

const {modeEditor, selectedHomeElement} = storeToRefs(editorStore)

const colorStroke = computed(() =>{
  return props.data.newElement ? "red" : "#584B01"
})
const selectedRoom = computed(()=>{
  return selected.value ? "green" : colorStroke.value
})
const selected = computed(()=>{
  return props.data?.id == selectedHomeElement.value.id
})
const colorBorder = computed( () =>{
  return '#584B01'
})
const colorFiil = computed(() => {
  return '#BAA635'
})
const pathIcon = computed( () => {
  let path = ''
  switch (props.data.type) {
    case 'rack' : path = 'rack.svg'
      break;
    case 'chair' : path = 'chair.svg'
      break;
    case 'sofa' : path = 'sofa.svg'
      break;
    case 'pc' : path = 'pc.svg'
      break;
    case 'mfu' : path = 'mfu.svg'
      break;
  }
  return path
})
const selectRoom = (e) => {
  e.preventDefault();
  if (modeEditor.value=='draw'){
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

const colorFill = computed(() => {
  let color = ''
  switch (props.data?.type){
    case 'silenceplace' :
      color = '#339542'
      break;
    case 'workplace' :
      color = '#2867B0'
      break;
    case 'softplace' :
      color = '#835615'
      break;
    case 'adminplace' :
      color = '#CA2D2D'
      break;
    case 'foodplace' :
      color = '#D48931'
      break;
    case 'otherplace' :
      color = '#848387'
      break;
  }
  return color
})

</script>

<template>
  <g>
    <rect
        :x="data?.positionStart.x"
        :y="data?.positionStart.y"
        :width="data?.size?.width"
        :height="data?.size?.height"
        :stroke="colorFill"
        stroke-width="2"
        stroke-dasharray="10"
        :fill="colorFill"
        fill-opacity=".1"
    />
    <foreignObject  :x="data?.positionStart.x"
                    :y="data?.positionStart.y">
      <!--                <img width="10" height="10" :src="require(pathIcon)"/>-->
    </foreignObject>
  </g>
</template>

<style scoped>

</style>