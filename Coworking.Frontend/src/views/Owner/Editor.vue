<script setup lang="ts">

import PageHeader from "../../components/Page/PageHeader.vue";
import EditorWorkPage from "../../components/Editor/EditorWorkPage.vue";
import Floor from "../../components/Editor/Floor.vue";
import EditorWorkElement from "../../components/Editor/EditorWorkElement.vue";
import {useEditorStore} from "../../store/useEditorStore.ts";
import {storeToRefs} from "pinia";
import {computed} from "vue";
import EditNode from "../../components/Editor/EditNode.vue";
import EditHomeElement from "../../components/Editor/EditHomeElement.vue";

const {selectNode, selectHomeElement} = storeToRefs(useEditorStore())


</script>

<template>
  <PageHeader>
    <template #header>
      <div class="header-wrapper" style="padding-left: 10px">
        <div class="left" style="display: flex; gap: 10px; flex-direction: column">
          <div class="name-coworking">
            <div class="name heading" style="font-size: 2rem; font-weight: 600">
              Бизнес-Центр
            </div>
          </div>
          <div class="level">
            <Floor :show-btn-edit="true" />
            <EditorWorkElement />
          </div>
        </div>
        <div class="right">
          <div class="search">

          </div>
          <div class="reservation">

          </div>
        </div>
      </div>
    </template>
    <template #content>
      <EditorWorkPage />
      <Sidebar v-model:visible="selectHomeElement" position="right" style="width: 300px" header="Редакторование зоны">
        <EditHomeElement />
      </Sidebar>
      <Sidebar v-model:visible="selectNode" position="right" style="width: 300px" header="Редакторование элемента">
        <EditNode />
      </Sidebar>
    </template>
  </PageHeader>
</template>

<style scoped>
.level{
  display: flex;
  gap: 10px
}
</style>
