<template>
    <a-card :bordered="selected">
        <p>{{name}}</p>
        <div>
            <a-space>
                <div class="properties">
                    Max {{subscriptions}} users,
                </div>
                <div class="properties">
                    Available for {{validMonths}} {{validMonths && validMonths < 2 ? 'month' : 'months' }},
                </div>
                <div class="properties">
                    {{priceMonth}}$ per month,
                </div>
                <div class="properties disabled">
                    No advanced board customization
                </div>
            </a-space>
        </div>
    </a-card>
</template>

<script lang="ts">
import { defineComponent } from 'vue';

interface Data {

}

export default defineComponent({
    props: {
        subscriptions: Number,
        name: String,
        validMonths: Number,
        priceMonth: Number,
        selected: Boolean
    },
    data(): Data {
        return {

        };
    },
    created() {

    },
    watch: {

    },
    methods: {

    }
});
</script>

<style>

</style>