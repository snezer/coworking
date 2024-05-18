<script setup lang="ts">
import Maps from "../components/Maps/Maps.vue";
import MPInformation from "../components/MainPage/MPInformation.vue";
import {computed, ref} from "vue";
import PlaceInformation from "../components/Maps/Place/PlaceInformation.vue";
import {storeToRefs} from "pinia";
import {useMapStore} from "../store/useMapStore.ts";


const mapsStore = useMapStore()
const {activePoint} = storeToRefs(mapsStore)

const openLeftPage = () => {
    mapsStore.resetActivePoint()
}
</script>

<template>
  <div class="main-page">
    <div class="information-wrapper" :class="{'out-focus': activePoint !== undefined}">
      <MPInformation />
    </div>
    <div class="maps-wrapper">
      <Maps />
    </div>
    <div class="place-information" :class="{'out-focus': activePoint == undefined}">
      <PlaceInformation />
    </div>
    <div class="hamburgMenu">
      <i class="pi pi-angle-double-left white-text" style="font-size: 2rem" @click="openLeftPage"></i>
    </div>
  </div>
</template>

<style scoped lang="css">
.main-page{
  position: relative;
  width: 100vw;
  height: 100vh;
  display: grid;
  grid-template-columns: repeat(12, 1fr) ;
  grid-template-rows: 1fr;
  overflow: hidden;
}
.information-wrapper{
  grid-area: 1 / 1 / 1 / span 7;
  z-index: 100;
  clip-path: polygon(0% 0%, 100% 0%, 50% 100%, 0% 100%);
  transition: transform 1s;
}
.information-wrapper.out-focus{
  transition: transform 1s;
  transform: translateX(-100%);
}
.maps-wrapper{
  grid-area: 1 / 1 / 1 / span 12;
  height: 100%;
  z-index: 99;
}
.place-information{
  height: 100%;
  grid-area: 1 / 6 / 1 / span 7;
  transition: transform 1s;
  background: var(--secondary-light);
  z-index: 100;
  clip-path: polygon(50% 0%, 100% 0%, 100% 100%, 0% 100%);
  box-shadow: 2px 0 3px 2px #ebebeb;
}
.place-information.out-focus{
  transform: translateX(100%);
}
.hamburgMenu{
  position: absolute;
  top: 0;
  left: 0;
  z-index: 99;
  height: 100vh;
  width: calc(100%/32);
  background: var(--primary);
  display: flex;
  justify-content: center;
  align-items: center;
}
</style>
