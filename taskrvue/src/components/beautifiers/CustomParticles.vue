<template>
    <Particles id="tsparticles" :options="options" :particlesInit="particlesInit" />
</template>

<script lang="ts">
import type { Engine } from "tsparticles-engine";
import { loadFull } from "tsparticles";

export default {
    data() {
        return {
            options: {
                fullScreen: {
                    enable: false,
                },
                particles: {
                    links: {
                        distance: 10,
                        enable: true,
                    },
                    move: {
                        enable: true,
                        speed: { min: 1, max: 3 },
                    },
                    opacity: {
                        value: { min: 0.1, max: 0.5 },
                    },
                    size: {
                        value: { min: 1, max: 3 },
                    },
                },
            }
        };
    },
    methods: {
        async particlesInit(engine: Engine) {
            await loadFull(engine);
        }
    }
}
</script>

<style>
    #tsparticles {
        height: 50px;
    }
</style>