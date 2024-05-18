<script setup lang="ts">

import PageHeader from "../../components/Page/PageHeader.vue";
import EditorWorkPage from "../../components/Editor/EditorWorkPage.vue";
import Floor from "../../components/Editor/Floor.vue";
import EditorWorkElement from "../../components/Editor/EditorWorkElement.vue";

</script>

<template>
  <PageHeader>
    <template #header>
      <div class="header-wrapper">
        <div class="left">
          <div class="name-coworking">
            Офис
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
    </template>
  </PageHeader>
</template>

<style scoped>

</style>
