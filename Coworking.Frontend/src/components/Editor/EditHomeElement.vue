<script setup lang="ts">



import {useEditorStore} from "../../store/useEditorStore.ts";
import {storeToRefs} from "pinia";
import {ref} from "vue";

const editorStore = useEditorStore()

const {selectedHomeElement} = storeToRefs(editorStore)

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

</script>

<template>
  <div class="edit-home-element">
    <div class="">
      <Dropdown tyle="width: 100%" v-model="selectedHomeElement.type" :options="homeElement" option-value="value" option-label="title"/>
    </div>
    <div>
      <FloatLabel>
        <Textarea v-model="selectedHomeElement.description" rows="5" cols="30" />
        <label>Описание</label>
      </FloatLabel>
    </div>
    <div>
      <FloatLabel>
        <InputText  id="selectlength" type="number" v-model="selectedHomeElement.lenght" />
        <label for="selectlength">Длина зоны</label>
      </FloatLabel>
    </div>
    <div>
      <FloatLabel>
        <InputText id="selectwidth" type="number" v-model="selectedHomeElement.width" />
        <label for="selectwidth">Ширина зоны</label>
      </FloatLabel>
    </div>
    <div class="actions" style="display: flex; justify-content: space-around;">
      <Button @click="editorStore.add_home_element(selectedHomeElement)">
        Сохранить
      </Button>
      <Button severity="danger" @click="editorStore.delete_home_element(selectedHomeElement)">
        Удалить
      </Button>
    </div>
  </div>
</template>

<style scoped>
.edit-home-element{
  width: 100%;
  height: 100%;
  display: flex;
  flex-direction: column;
  justify-content: stretch;
  gap: 20px;
}
</style>