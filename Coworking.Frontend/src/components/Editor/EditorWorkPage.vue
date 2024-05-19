<script setup lang="ts">

import {computed, onMounted, ref} from "vue";
import {storeToRefs} from "pinia";
import {useEditorStore} from "../../store/useEditorStore.ts";
import HomeElemtnWrapper from "./HomeElemtnWrapper.vue";
import HomeElement from "./HomeElement.vue";
import NodeWrapper from "./Node/NodeWrapper.vue";

const editorStore = useEditorStore()

const {
  modeEditor,
  drawTypeElement,
  selectFloorId,
  floors,
    visiblePhotoLevel
} = storeToRefs(editorStore)

const drawHomeElement = computed(()=>{
  return modeEditor.value==='draw'
})


const zoom = ref(1)
const    newHomeElement = ref<any>( null)
const    stageDrawHomeElement = ref( 'start')
const    drawTypeHomeElement = ref( 'node')
const    drawMove = ref( false) //отображать рисованную фигуру только тогда включил рисование сделал клик и повел
const    startX = ref( null)
const    startY = ref( null)

const onMouseMove = function (e) {
  //console.log(this.newHomeElement)
  const x = e.clientX - 280;
  const y = e.clientY -100;

  if (drawHomeElement.value) {
    newHomeElement.value = {
      positionStart: {
        x: Math.min(x, startX.value),
        y: Math.min(y, startY.value),
      },
      size: {
        width: Math.abs(x - startX.value),
        height: Math.abs(y - startY.value),
      },
      type: drawTypeElement.value,
      newElement: true,
    }
  }
}
const onClick = function (e) {
  const x = e.clientX-280;
  const y = e.clientY-100;
  //если стоит галка рисования то рисуем объекты
  if (drawHomeElement.value){
    switch (drawTypeElement.value) {
      case 'silenceplace' :
      case 'workplace' :
      case 'softplace' :
      case 'adminplace' :
      case 'foodplace' :
      case 'otherplace' :
      {
        switch (stageDrawHomeElement.value) {
          case 'start' :
            startX.value = x
            startY.value = y
            newHomeElement.value = {
              positionStart: {
                x: x,
                y: y,
              }
            }
            stageDrawHomeElement.value = 'end'
            break;
          case 'end' :
            editorStore.add_home_element({
              positionStart: newHomeElement.value.positionStart,
              size: {
                width: Math.abs(x  - startX.value),
                height: Math.abs(y - startY.value),
              },
              type: drawTypeElement.value,
            })
            startX.value = null;
            startY.value = null;
            stageDrawHomeElement.value = 'start'

        }
        break;
      }
      case 'door' :
      case 'stair' :
      case 'audio2' :
      case 'audioall' :
      case 'chair' :
      case 'coffeemachine' :
      case 'computer' :
      case 'cooler' :
      case 'fridge' :
      case 'printer' :
      case 'reception' :
      case 'round' :
      case 'table' :
      case 'teaport1' :
      case 'toilet' :
      case 'tv' : {
        editorStore.add_node({
          positionStart: {
            x: x,
            y: y,
          }
        })

        break
      }
    }

  } else { //иначе выбираем их для редактирования
    editorStore.unselect()
  }
}

const selectFloor = () => {
  return floors.value.find(n=>n.id==selectFloorId.value)
}

onMounted(() => {
  editorStore.get_all_home_elements()
  editorStore.get_all_nodes()
})

import podl from'../../assets/image/podl.png'
</script>

<template>
  <div style="height: 100%; width: 100%; position: relative;">
    <div style="height: 100%; width: 100%; position: relative" @click="onClick">
      <svg>
        <image
            style="opacity: 0; filter: invert(1)"
            :style="`opacity: ${visiblePhotoLevel ? .4 : 0};`"
            :href="podl"
            x="50"
            y="-50"
            width="1000"
            height="1000"
        />
      </svg>
      <svg
          @mousemove="onMouseMove"
      ><g>

        <HomeElemtnWrapper />
        <HomeElement
            v-show="stageDrawHomeElement!=='start'"
            :data="newHomeElement"
        />
        <NodeWrapper />
      </g>
      </svg>
    </div>
  </div>
</template>

<style scoped>
scheme{
  opacity: 0.5;
  filter: invert(1);
}
svg {
  position: absolute;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  z-index: 0;
}
</style>