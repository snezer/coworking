<script setup lang="ts">

import {YandexMapDefaultMarker, YandexMapMarkerPosition} from "vue-yandex-maps";
import {ref} from "vue";
import {useMapStore} from "../../../store/useMapStore.ts";

const props = defineProps({
  point: {
    type: Object,
    required: true,
  }
})

type PartialRecord<K extends keyof any, T> = {
  [P in K]?: T;
};


const positionsX = {
  left: 'left',
  right: 'right',
  'right-center': 'right-center',
  'left-center': 'left-center',

  custom: '-25%',

  default: 'default',
} satisfies PartialRecord<YandexMapMarkerPosition | 'custom', string>;

const positionsY = {
  top: 'top',
  bottom: 'bottom',
  'top-center': 'top-center',
  'bottom-center': 'bottom-center',

  custom: '-25%',

  default: 'default',
} satisfies PartialRecord<YandexMapMarkerPosition | 'custom', string>;

const positionX = ref<keyof typeof positionsX>('default');
const positionY = ref<keyof typeof positionsY>('default');

const diagramBackground = (colors: { percentage: number, color: string }[]): string => {
  const gradient = [];
  let previous = 0;
  for (let i = 0; i < colors.length; i += 1) {
    const p = colors[i];
    const deg = (360 / 100) * p.percentage;
    gradient.push(`${p.color} ${previous}deg ${previous + deg}deg`);
    previous += deg;
  }

  return `conic-gradient(${gradient.join(', ')})`;
};

const mapStore = useMapStore()

const selectPoint = () => {
  mapStore.setActivePoint(props.point)
}

</script>

<template>
  <yandex-map-marker
      style="z-index: 100"
      v-if="'element' in point"
      :settings="{...point, onClick: selectPoint}"
      :position="`${positionX} ${positionY}` as any"
      :style="{
        '--color': 'color' in point && point.color,
        '--image': 'colors' in point && diagramBackground(point.colors),
      }"
  >
    <template v-if="point.element === 'diagram'">
      <div
          v-if="'title' in point"
          class="pie-marker-title"
      >
        {{ point.title }}
      </div>
      <div
          class="pie-marker"
      />
    </template>
    <div
        v-else-if="point.element === 'circle'"
        class="circle"
        :style="{
          '--radius': 'radius' in point ? point.radius : '20px',
          '--color': 'color' in point ? point.color : undefined,
          '--icon': 'icon' in point ? point.icon : '#fff',
          '--image': 'icon' in point ? point.icon : undefined,
        }"
        :title="'title' in point && point.title"
    >
      <div class="circle_element" />
    </div>
    <div
        v-else-if="point.element === 'icon'"
        class="icon"
        :style="{
          '--size': 'size' in point ? point.size : '20px',
          '--color': 'color' in point ? point.color : undefined,
          '--icon': 'icon' in point ? `url(${point.icon})` : undefined,
        }"
    >
      <div
          v-if="'title' in point"
          class="icon_title"
          v-html="point.title"
      />
    </div>
  </yandex-map-marker>
  <yandex-map-default-marker
      v-else
      :settings="{...point, onClick: selectPoint}"
      @click="selectPoint"
  />
</template>

<style scoped>
select {
  border: 1px solid #000;
  padding-left: 5px;
}

.pie-marker-title {
  position: absolute;
  top: 120%;
  left: 50%;
  padding: 2px 4px;
  background-color: #fff;
  transform: translateX(-50%);
  color: var(--color);
}

.pie-marker {
  background-color: currentColor;
  background-image: var(--image);
  width: 50px;
  height: 50px;
  border-radius: 50%;
  overflow: hidden;
}

.circle {
  width: var(--radius);
  height: var(--radius);
  border-radius: 50%;
  background-color: currentColor;
  color: var(--color);
}

.circle_element {
  position: absolute;
  top: 50%;
  left: 50%;
  display: inline-block;
  width: 50%;
  height: 50%;
  border-radius: 50%;
  background: #fff var(--image) no-repeat center center;
  transform: translate3d(-50%, -50%, 0);
}

.icon {
  position: relative;
  width: var(--size);
  height: var(--size);
  color: var(--color);
  background: var(--icon) no-repeat center center / contain;
}

.icon_title {
  position: absolute;
  top: 120%;
  left: 50%;
  padding: 2px 4px;
  background-color: #fff;
  transform: translateX(-50%);
}
</style>