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
                        distance: 10, // maximum distance for linking the particles
                        enable: true, // enabling this will make the particles linked together
                    },
                    move: {
                        enable: true, // enabling this will make particles move in the canvas
                        speed: { min: 1, max: 5 }, // using a range in speed value will make particles move in a random speed between min/max values, each particle has its own value, it won't change over time by default
                    },
                    opacity: {
                        value: { min: 0.3, max: 0.7 }, // using a different opacity, to have some semitransparent effects
                    },
                    size: {
                        value: { min: 1, max: 3 }, // let's randomize the particles size a bit
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
        height: 10px;
    }
</style>