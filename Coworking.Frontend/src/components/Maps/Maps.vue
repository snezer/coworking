<script setup lang="ts">
import {ref, shallowRef} from 'vue';
import type { YMap } from '@yandex/ymaps3-types';
import {
  YandexMap, YandexMapDefaultFeaturesLayer,
  YandexMapDefaultMarker,
  YandexMapDefaultSchemeLayer,
  YandexMapMarkerPosition
} from 'vue-yandex-maps';
import {useMapStore} from "../../store/useMapStore.ts";
import {storeToRefs} from "pinia";
import Marker from "./Marker/Marker.vue";



//Можно использовать для различных преобразований
const map = shallowRef<null | YMap>(null);

const {points} = storeToRefs(useMapStore())

</script>

<template>
  <YandexMap
      v-model="map"
      :settings="{
        location: {
          center: [83.729287, 53.345223],
          zoom: 13,
        },
      }"
      width="100%"
      height="100%"
  >
    <YandexMapDefaultSchemeLayer/>
    <yandex-map-default-features-layer />
    <template v-for="point in points" :key="point.coordinates.toString()">
      <Marker :point="point" />
    </template>
  </YandexMap>
</template>

<style scoped>

</style>
