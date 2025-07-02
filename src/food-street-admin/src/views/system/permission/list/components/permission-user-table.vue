<script setup lang="ts">
import { Table, Button } from "ant-design-vue";

const dataSource = [
  {
    key: "1",
    name: "胡彦斌",
    age: 32,
    address: "西湖区湖底公园1号",
    operation: "1",
  },
  {
    key: "2",
    name: "胡彦祖",
    age: 42,
    address: "西湖区湖底公园1号",
    operation: "1",
  },
  {
    key: "2",
    name: "胡彦祖",
    age: 42,
    address: "西湖区湖底公园1号",
    operation: "1",
  },
  {
    key: "2",
    name: "胡彦祖",
    age: 42,
    address: "西湖区湖底公园1号",
    operation: "1",
  },
  {
    key: "2",
    name: "胡彦祖",
    age: 42,
    address: "西湖区湖底公园1号",
    operation: "1",
  },
  {
    key: "2",
    name: "胡彦祖",
    age: 42,
    address: "西湖区湖底公园1号",
    operation: "1",
  },
];

const columns = [
  {
    title: "姓名",
    dataIndex: "name",
    key: "name",
  },
  {
    title: "年龄",
    dataIndex: "age",
    key: "age",
  },
  {
    title: "住址",
    dataIndex: "address",
    key: "address",
  },
  {
    title: "操作 (前往为用户授权)",
    dataIndex: "operation",
    key: "operation",
  },
];
</script>

<template>
  <div>
    <h1 class="!pt-2">用户列表</h1>
    <h3 class="text-sm text-gray-400">此权限下的一些用户</h3>
    <Table :columns="columns" :data-source="dataSource" bordered>
      <template #bodyCell="{ column }">
        <span v-if="column.dataIndex === 'operation'">
          <Button type="link">前往授权</Button>
        </span>
      </template>
    </Table>
  </div>
</template>

<style scoped></style>
