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
    title: 'Тихая зона',
    icon: 'room.svg',
    value: 'silenceplace'
  },
  {
    title: 'Рабочая зона',
    icon: 'rack.svg',
    value: 'workplace'
  },
  {
    title: 'Мягкая зона',
    icon: 'chair.svg',
    value: 'softplace'
  },
  {
    title: 'Зона администрации',
    icon: 'placeforread.svg',
    value: 'adminplace'
  },
  {
    title: 'Фудкорд',
    icon: 'sofa.svg',
    value: 'foodplace'
  },
  {
    title: 'Прочее',
    icon: 'pc.svg',
    value: 'otherplace'
  }
])

const nodeElements = ref([
  {
    title: 'Стол',
    icon: 'table.svg',
    value: 'table'
  },
  {
    title: 'Принтер',
    icon: 'printer.svg',
    value: 'printer'
  },
  {
    title: 'Колонки',
    icon: 'audio2.svg',
    value: 'audio2'
  },
  {
    title: 'Колонки большие',
    icon: 'audioall.svg',
    value: 'audioall'
  },
  {
    title: 'Кресло',
    icon: 'chair.svg',
    value: 'chair'
  },
  {
    title: 'Кофемашина',
    icon: 'coffeeemachine.svg',
    value: 'coffeeemachine'
  },
  {
    title: 'Компьютер',
    icon: 'computer.svg',
    value: 'computer'
  },{
    title: 'Куллер',
    icon: 'cooler.svg',
    value: 'cooler'
  },{
    title: 'Холодильник',
    icon: 'fridge.svg',
    value: 'fridge'
  },{
    title: 'Ресепшен',
    icon: 'reception.svg',
    value: 'reception'
  },{
    title: 'Круглый стол',
    icon: 'round.svg',
    value: 'round'
  },
  {
    title: 'Чайник',
    icon: 'teaport1.svg',
    value: 'teaport1'
  },
  {
    title: 'Туалет',
    icon: 'toilet.svg',
    value: 'toilet'
  },
  {
    title: 'Телевизор',
    icon: 'tv.svg',
    value: 'tv'
  },
])

</script>

<template>
  <div style="display: flex; gap: 10px; flex-direction: column;">
    <span>Редактор карты помещения</span>
    <div style="display: flex; gap: 5px; align-items: center;">
      <div class="mode">
        <SelectButton v-model="modeEditor" :options="modes" option-label="title" option-value="event" />
      </div>
      <div class="element" style="display: flex; gap: 5px">
        <Dropdown v-model="drawTypeElement" :options="homeElement" placeholder="Зоны" option-label="title" option-value="value">
        </Dropdown>
        <Dropdown v-model="drawTypeElement" :options="nodeElements" placeholder="Интерьер" option-label="title" option-value="value">
        </Dropdown>
      </div>
    </div>
  </div>

</template>

<style scoped>

</style>