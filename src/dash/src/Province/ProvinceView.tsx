import useProvince from "./useProvince";

function ProvinceView() {
  const { provinces } = useProvince();
  return (
    <div>
      <pre>{JSON.stringify(provinces, null, 2)}</pre>
    </div>
  );
}

export default ProvinceView;
