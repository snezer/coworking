<script setup lang="ts">

import {ref} from "vue";
import {useEditorStore} from "../../store/useEditorStore.ts";
import {storeToRefs} from "pinia";

const editorStore = useEditorStore()

const {modeEditor,drawTypeElement } = storeToRefs(editorStore)

const modes = ref([
  {
    title: 'Рисование',
    icon: 'edit',
    event: 'draw'
  },
  {
    title: 'Выбор объекта',
    icon: 'check',
    event: 'select'
  }
])

const homeElement = ref([
  {
    title: 'Комната',
    icon: 'room.svg',
    value: 'room'
  },
  {
    title: 'Стеллаж',
    icon: 'rack.svg',
    value: 'rack'
  },
  {
    title: 'Кафедра',
    icon: 'chair.svg',
    value: 'chair'
  },
  {
    title: 'Место для чтения',
    icon: 'placeforread.svg',
    value: 'placeforread'
  },
  {
    title: 'Диван',
    icon: 'sofa.svg',
    value: 'sofa'
  },
  {
    title: 'Стол с ПК',
    icon: 'pc.svg',
    value: 'pc'
  },
  {
    title: 'МФУ',
    icon: 'mfu.svg',
    value: 'mfu'
  },
])

const nodeElements = ref([
  {
    title: 'Дверь',
    icon: 'door.svg',
    value: 'door'
  },
  {
    title: 'Лестница',
    icon: 'stair.svg',
    value: 'stair'
  },
  {
    title: 'Лифт',
    icon: 'elevator.svg',
    value: 'elevator'
  }
])

</script>

<template>
  <div>
    <div class="mode">
      <SelectButton v-model="modeEditor" :options="modes" option-label="title" option-value="event" />
    </div>
    <div class="element">
      <Dropdown v-model="drawTypeElement" :options="homeElement" placeholder="Элементы здания" option-label="title" option-value="value">
      </Dropdown>
      <Dropdown v-model="drawTypeElement" :options="nodeElements" placeholder="Интерьер" option-label="title" option-value="value">
      </Dropdown>
    </div>
  </div>
</template>

<style scoped>

</style>