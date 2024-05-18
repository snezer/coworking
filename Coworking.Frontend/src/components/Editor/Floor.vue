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

const {floors, selectFloorId} =storeToRefs(editorStore)

const handleFilesEducationUpload = async function (event) {
  console.log(1)
  const files = event.files[0]

  console.log(files)
  let formData = new FormData()
  console.log(files)
  for (let i = 0; i < files.length; i++) {
    let file = files[i]
    formData.append('files', file)
  }
  filesEdu.value = formData
  editorStore.add_image_for_floor(formData)
}

onMounted(() => {
  editorStore.get_all_floors()
})
</script>

<template>
  <div>
    <Dropdown
        v-model="selectFloorId"
        :options="floors"
        option-label="title"
        option-value="id"
        placeholder="Выберите этаж"
    />
    <Button  v-show="showBtnEdit"
            @click="editorStore.add_floor({title: '3', value: 0, coworking: '66481bad730f18df6aac9152', image: ''})"
    > + этаж
    </Button>
      <FileUpload
          v-show="showBtnEdit"
          accept="image/png, image/jpeg, image/bmp"
          placeholder="План этажа"
          multiple
          type="file"
          id="filesEducation"
          ref="filesEducation"
          mode="basic"
          custom-upload
          @uploader="handleFilesEducationUpload"
      >+</FileUpload>
    <Button  v-show="showBtnEdit"
            @click="editorStore.delete_floor(selectFloorId)"
    > Удалить выбранный этаж
    </Button>
  </div>
</template>

<style scoped>

</style>