<template>
        <a-row>
            <a-col span="7">
                <OfferCard :selected="false"></OfferCard>
            </a-col>
            <a-col span="1"></a-col>
            <a-col span="8">
                <OfferCard :selected="true"></OfferCard>
            </a-col>
            <a-col span="1"></a-col>
            <a-col span="7">
                <OfferCard :selected="false"></OfferCard>
            </a-col>
        </a-row>
        <div class="blades">
            <OfferBlade :selected="false"></OfferBlade>
        </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue';
import OfferBlade from './OfferBlade.vue';
import OfferCard from './OfferCard.vue';

type LicenseTypes = {
    id: number,
    subscriptions: number,
    name: string,
    validMonths: number,
    priceMonth: number
}[];

interface Data {
    loading: boolean,
    licenses: null | LicenseTypes,
}

export default defineComponent({
    components: {
        OfferBlade,
        OfferCard
    },
    data(): Data {
        return {
            loading: false,
            licenses: null
        };
    },
    created() {
        this.fetchData();
    },
    watch: {
        '$route': 'fetchData'
    },
    methods: {
        fetchData(): void {
            this.loading = true;

            fetch('fetchLicenses')
                .then(r => r.json())
                .then(json => {
                    this.licenses = json as LicenseTypes;
                    this.loading = false;
                    return;
                });
        }
    }
});
</script>

<style>
.ant-card-bordered {
    border-color: rgb(0, 140, 255) !important;
    border-radius: 10px 10px !important;
    border-style: dashed !important;
    border-width: 3px !important;
}

.blades {
    margin-top: 5px;
}
</style>