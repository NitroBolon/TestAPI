<template>
        <a-row>
            <a-col span="7">
                <OfferCard :selected="false" v-if="licenses && licenses?.length > 1" 
                    :name="licenses[1].name" 
                    :price-month="licenses[1].priceMonth" 
                    :subscriptions="licenses[1].subscriptions"
                    :valid-months="licenses[1].validMonths"></OfferCard>
                <a-skeleton v-else></a-skeleton>
            </a-col>
            <a-col span="1"></a-col>
            <a-col span="8">
                <OfferCard :selected="true" v-if="licenses && licenses?.length > 0" 
                    :name="licenses[0].name" 
                    :price-month="licenses[0].priceMonth" 
                    :subscriptions="licenses[0].subscriptions"
                    :valid-months="licenses[0].validMonths"></OfferCard>
                <a-skeleton v-else></a-skeleton>
            </a-col>
            <a-col span="1"></a-col>
            <a-col span="7">
                <OfferCard :selected="false" v-if="licenses && licenses?.length > 2" 
                    :name="licenses[2].name" 
                    :price-month="licenses[2].priceMonth" 
                    :subscriptions="licenses[2].subscriptions"
                    :valid-months="licenses[2].validMonths"></OfferCard>
                <a-skeleton v-else></a-skeleton>
            </a-col>
        </a-row>
        <div class="blades" v-if="licenses && licenses?.length > 3">
            <OfferBlade :selected="false" v-for="license in licensesBlades" v-bind:key="license.id"></OfferBlade>
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
    licensesBlades: null | LicenseTypes
}

export default defineComponent({
    components: {
        OfferBlade,
        OfferCard
    },
    data(): Data {
        return {
            loading: false,
            licenses: null,
            licensesBlades: null
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
                    if (this.licenses && this.licenses.length > 3) {
                        this.licensesBlades = this.licenses.slice(3);
                    }
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