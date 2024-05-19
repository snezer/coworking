<script setup lang="ts">

import {useEditorStore} from "../../store/useEditorStore.ts";
import {storeToRefs} from "pinia";
import {ref,defineProps} from "vue";

defineProps({
  modeAdmin:{
    type: Boolean,
    default: true
  }
})

import {useDialog} from "primevue/usedialog";

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

const handleSave = async () => {
  await editorStore.add_node(selectedNode.value)
}

const rentVisible = ref(false)

const hours = ref(1)
const datetime24h = ref()
</script>

<template>
  <div class="edit-node">
    <div class="">
      <Dropdown v-model="selectedNode.type" style="width: 100%" :options="nodeElements" option-value="value" option-label="title"/>
    </div>
    <div>
      <FloatLabel>
        <Textarea :readonly="!modeAdmin" v-model="selectedNode.description" rows="5" cols="30" tyle="width: 100%" />
        <label>Описание</label>
      </FloatLabel>
    </div>
    <div tyle="width: 100%">
      <FloatLabel>
        <InputText :readonly="!modeAdmin"  id="cost" type="number" min="0" tyle="width: 100%" v-model="selectedNode.cost" />
        <label for="cost">Цена</label>
      </FloatLabel>
    </div>
    <div :hidden="!modeAdmin">
      <FloatLabel>
        <InputText :readonly="!modeAdmin"  id="cost1" type="number" min="40" v-model="selectedNode.scale" />
        <label for="cost1">Размер</label>
      </FloatLabel>
    </div>
    <div :hidden="!modeAdmin">
      <FloatLabel>
        <InputText  id="cost11" type="number"  v-model="selectedNode.rotation" />
        <label for="cost11">Вращение</label>
      </FloatLabel>
    </div>
    <div :hidden="!modeAdmin" class="">
      <FileUpload mode="basic" name="demo[]" accept="image/*" style="background: #eec77e;color: #1a1a1a; font-weight: 600; text-align: center;" choose-label="Выбрать фото" />
    </div>
    <div >

    </div>
  <div class="actions">
    <Button style="background: #eec77e;color: #1a1a1a; font-weight: 600; text-align: center;" @click="rentVisible=true" label="Арендовать"></Button>
    <Button style="background: #eec77e;color: #1a1a1a; font-weight: 600; text-align: center;" @click="handleSave" label="Сохранить">

    </Button>
    <Button severity="danger" @click="editorStore.delete_node(selectedNode)" label="Удалить">

    </Button>
  </div>
  </div>

  <Dialog v-model:visible="rentVisible" modal :header="`Офрмление аренды`" :style="{ width: '300px' }">
    <div class="rent">
      <FloatLabel>
        <Calendar style="width: 258px" :invalid="!datetime24h" id="calendar-24h" v-model="datetime24h" showTime hourFormat="24" />
        <label for="calendar-24h">Время начало аренды</label>
      </FloatLabel>
      <FloatLabel>
        <InputNumber style="width: 258px" id="hours" v-model="hours" type="number"/>
        <label for="hours">Количество часов</label>
      </FloatLabel>
      <div style="font-weight: 600; ">
        Стоимость аренды составит: <span class="red-text">{{hours*selectedNode.cost}}</span>
      </div>
      <Button style="background: #eec77e;color: #1a1a1a; font-weight: 600; text-align: center;" @click="rentVisible=false">
        Подтвердить аренду
      </Button>

    </div>

  </Dialog>
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
.rent{
  margin-top: 10px;
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: stretch;
  gap: 20px
}
.actions{
  display: flex;
  flex-direction: column;
  gap: 10px;
}
</style>