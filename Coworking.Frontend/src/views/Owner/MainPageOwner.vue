<script setup lang="ts">

import Navigation from "../../components/Navigation/Navigation.vue";
</script>

<template>
  <div class="main-page-owner-wrapper">
    <div class="navigation">
      <Navigation />
    </div>
    <div class="page">
      <router-view name="owner"></router-view>
    </div>
  </div>
</template>

<style scoped>
.main-page-owner-wrapper{
  position: relative;
  width: 100vw;
  height: 100vh;
  display: grid;
  grid-template-columns: 280px 1fr;
}
.page{
  position: relative;
  width: 100%;
  height: 100%;
}
</style>