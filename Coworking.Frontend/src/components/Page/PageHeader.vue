<script setup lang="ts">

import Page from "./Page.vue";
</script>

<template>
      <div class="page-header">
        <div class="header">
          <slot name="header"></slot>
        </div>
        <div class="content">
          <slot name="content"></slot>
        </div>
      </div>
</template>

<style scoped>
.page-header{
  position: relative;
  width: 100%;
  height: 100%;
  display: grid;
  grid-template-rows: 100px 1fr;
  background: var(--background-gray);
}
.header{
  width: 100%;
  height: 100%;
}
.content{
  height: 100%;
  width: 100%;
}
</style>