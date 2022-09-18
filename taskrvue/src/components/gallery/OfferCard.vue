<template>
    <a-card :title="name" :bordered="selected">
        <a-space>
            <star-filled></star-filled>
            <star-filled></star-filled>
            <star-filled v-if="selected"></star-filled>
            <star-outlined v-if="!selected"></star-outlined>
        </a-space>
        <p v-if="selected">One of best offers!</p>
        <p v-else>Another interesting offer!</p>
        <br />
        <div>
            <div class="properties">
                <check-outlined></check-outlined>
                Max {{subscriptions}} users
            </div>
            <br />
            <div class="properties">
                <check-outlined></check-outlined>
                Available for {{validMonths}} {{validMonths && validMonths < 2 ? 'month' : 'months'}}
            </div>
            <br />
            <div class="properties">
                <check-outlined></check-outlined>
                Only {{priceMonth}}$ per month
            </div>
            <br />
            <div class="properties disabled">
                <close-outlined></close-outlined>
                Advanced board customization
            </div>
        </div>
    </a-card>
</template>

<script lang="ts">
import { defineComponent } from 'vue';
import { StarOutlined, StarFilled, CheckOutlined, CloseOutlined } from '@ant-design/icons-vue';

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
    components: {
        StarOutlined,
        StarFilled,
        CheckOutlined,
        CloseOutlined
    },
    data(): Data {
        return {

        };
    },
    setup() {

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
.properties {
    float: left;
}

.disabled {
    opacity: 50%;
}
</style>