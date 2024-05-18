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

const colorStroke = computed(()=>{
  return props.data.newElement ? "red" : "#1565c0"
})
const selectedRoom = computed(()=>{
  return selected.value ? "green" : colorStroke.value
})
const selected = computed(()=>{
  return props.data.id == selectedHomeElement.value.id
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

    editorStore.selectHomeElement(props.data)
    e.stopPropagation();
  }

}
</script>

<template>
  <g>
    <rect
        :x="data?.positionStart.x"
        :y="data?.positionStart.y"
        :width="data?.size.width"
        :height="data?.size.height"
        :stroke="selectedRoom"
        stroke-width="5"
        stroke-dasharray="20"
        fill="#eee"
        fill-opacity=".4"
    />
    <foreignObject  :x="data?.positionStart.x"
                    :y="data?.positionStart.y"
                    :width="data?.size.width"
                    :height="data?.size.height">
      <div style="color: red;" class="text-center">
        {{data.name}}
      </div>
    </foreignObject>
  </g>
</template>

<style scoped>

</style>