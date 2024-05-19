<script setup lang="ts">


import {useEditorStore} from "../../store/useEditorStore.ts";
import {storeToRefs} from "pinia";
import {ref} from "vue";

const editorStore = useEditorStore()

const {selectedNode} = storeToRefs(editorStore)


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
  <div class="edit-node">
    <div class="">
      <Dropdown v-model="selectedNode.type" style="width: 100%" :options="nodeElements" option-value="value" option-label="title"/>
    </div>
    <div>
      <FloatLabel>
        <Textarea v-model="value" rows="5" cols="30" tyle="width: 100%" />
        <label>Описание</label>
      </FloatLabel>
    </div>
    <div tyle="width: 100%">
      <FloatLabel>
        <InputText  id="cost" type="number" tyle="width: 100%" v-model="selectedNode.cost" />
        <label for="cost">Цена</label>
      </FloatLabel>
    </div>
    <div>
      <FloatLabel>
        <InputText  id="cost1" type="number" min="40" v-model="selectedNode.scale" />
        <label for="cost1">Размер</label>
      </FloatLabel>
    </div>
    <div>
      <FloatLabel>
        <InputText  id="cost11" type="number"  v-model="selectedNode.rotation" />
        <label for="cost11">Вращение</label>
      </FloatLabel>
    </div>
    <div class="">
      <FileUpload mode="basic" name="demo[]" accept="image/*" choose-label="Выбрать фото" />
    </div>
  <div class="actions">
    <Button @click="editorStore.add_node(selectedNode)">
      Сохранить
    </Button>
    <Button severity="danger" @click="editorStore.delete_node(selectedNode)">
      Удалить
    </Button>
  </div>
  </div>
</template>

<style scoped>
.edit-node{
  width: 100%;
  height:100%;
  display: flex;
  flex-direction: column;
  justify-content: stretch;
  gap: 20px
}
</style>