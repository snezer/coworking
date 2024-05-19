<script setup lang="ts">
import {defineProps, ref, onMounted} from 'vue'
import {useEditorStore} from "../../store/useEditorStore.ts";
import {storeToRefs} from "pinia";

const props = defineProps({
  showBtnEdit: {
    type: Boolean
  }
})

const filesEdu = ref('')

const editorStore = useEditorStore()

const {floors, selectFloorId, visiblePhotoLevel} =storeToRefs(editorStore)

const handleFilesEducationUpload = async (event) => {
  console.log(1)
  const files = event.files[0]
  let formData = new FormData()
  for (let i = 0; i < files.length; i++) {
    let file = files[i]
    formData.append('files', file)
  }
  //await editorStore.add_image_for_floor(formData)
  setTimeout(function (){
    visiblePhotoLevel.value = true
  }, 1000)
}

onMounted(() => {
  editorStore.get_all_floors()
})
const handleAddFloor = async () => {
  await editorStore.add_floor({title: '3', value: 0, coworking: '66481bad730f18df6aac9152', image: ''})
}
</script>

<template>
  <div style="display: flex; flex-direction: column; gap: 10px;">
    <span>Редактор этажей</span>
    <div style="display: flex; align-items: center; gap: 5px">
      <div>
        <Dropdown
            v-model="selectFloorId"
            :options="floors"
            option-label="title"
            option-value="id"
            placeholder="Выберите этаж"
        />
      </div>
      <div>
        <Button  v-show="showBtnEdit"
                 @click="handleAddFloor"
                 style="background: #eec77e;color: #1a1a1a; font-weight: 600; text-align: center;"
                 label="+ этаж"
        >
        </Button>
      </div>
      <div>
        <FileUpload
            :auto="true"
            v-show="showBtnEdit"
            accept="image/png, image/jpeg, image/bmp"
            placeholder="План этажа"
            name="demo[]"
            mode="basic"
            custom-upload
            choose-label="План этажа"
            @uploader="handleFilesEducationUpload"
            style="background: #eec77e;color: #1a1a1a; font-weight: 600; text-align: center;"
        ></FileUpload>
      </div>
      <div>
        <Button  v-show="showBtnEdit"
                 @click="editorStore.delete_floor(selectFloorId)"
                 style="background: #eec77e;color: #1a1a1a; font-weight: 600; text-align: center;"
                 label="Удалить этаж"
        >
        </Button>
      </div>


    </div>
  </div>

</template>

<style scoped>

</style>