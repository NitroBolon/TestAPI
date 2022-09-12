<template>
    <div class="post">
        <div v-if="loading" class="loading">
            Loading... Please refresh once the ASP.NET backend has started. See <a href="https://aka.ms/jspsintegrationvue">https://aka.ms/jspsintegrationvue</a> for more details.
        </div>

        <a-table :dataSource="post" :columns="columns"/>
    </div>
</template>

<script lang="ts">
    import { defineComponent } from "vue";

    type Columns = {
        title: string,
        dataIndex: string,
        key: string
    }[];

    type Forecasts = {
        date: string,
        temperatureC: number,
        temperatureF: number,
        summary: string
    }[];

    interface Data {
        loading: boolean,
        post: null | Forecasts,
        columns: null | Columns
    }

    export default defineComponent({
        data(): Data {
            return {
                loading: false,
                post: null,
                columns: [
                    {
                      title: 'Date',
                      dataIndex: 'date',
                      key: 'date',
                    },
                    {
                      title: 'Temperature (C)',
                      dataIndex: 'temperatureC',
                      key: 'temperatureC',
                    },
                    {
                      title: 'Temperature (F)',
                      dataIndex: 'temperatureF',
                      key: 'temperatureF',
                    },
                    {
                      title: 'Summary',
                      dataIndex: 'summary',
                      key: 'summary',
                    },
                ]
            };
        },
        created() {
            // fetch the data when the view is created and the data is
            // already being observed
            this.fetchData();
        },
        watch: {
            // call again the method if the route changes
            '$route': 'fetchData'
        },
        methods: {
            fetchData(): void {
                this.post = null;
                this.loading = true;

                fetch('weatherforecast')
                    .then(r => r.json())
                    .then(json => {
                        this.post = json as Forecasts;
                        this.loading = false;
                        return;
                    });
            }
        },
    });
</script>