<script setup lang="ts">

import EditorWorkPage from "../components/Editor/EditorWorkPage.vue";
import PageHeader from "../components/Page/PageHeader.vue";
import EditNode from "../components/Editor/EditNode.vue";
import EditHomeElement from "../components/Editor/EditHomeElement.vue";
import {storeToRefs} from "pinia";
import {useEditorStore} from "../store/useEditorStore.ts";
import Floor from "../components/Editor/Floor.vue";
import EditorWorkElement from "../components/Editor/EditorWorkElement.vue";
import {onMounted} from "vue";

const {selectNode, selectHomeElement} = storeToRefs(useEditorStore())
const editorStore = useEditorStore()
const {modeEditor } = storeToRefs(editorStore)

onMounted(() => {
  modeEditor.value = 'select'
})
</script>

<template>
  <div style="width: 100vw; height: 100vh;">
    <PageHeader>
      <template #header="">
        <div class="left" style="display: flex; gap: 10px; flex-direction: column">
          <div class="name-coworking">
            <div class="name heading" style="font-size: 2rem; font-weight: 600">
              Заказ в Бизнес-Центре
            </div>
          </div>
          <div class="level">
            <Floor :show-btn-edit="false" />
          </div>
        </div>
      </template>
      <template #content>
        <EditorWorkPage />
        <Sidebar v-model:visible="selectNode" position="right" style="width: 300px" header="Редакторование элемента">
          <EditNode :mode-admin="false" />
        </Sidebar>
      </template>
    </PageHeader>
  </div>

</template>

<style scoped>

</style>