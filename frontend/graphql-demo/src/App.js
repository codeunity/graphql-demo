import { gql, useSubscription } from "@apollo/client";

const CURRENT_DATE_TIME_SUBSCRIPTION = gql`
  subscription {
    currentDateTime
  }
`;

const App = () => {

  const { data, loading } = useSubscription(CURRENT_DATE_TIME_SUBSCRIPTION);

  return (
    <div className="h-screen flex justify-center items-center text-xl">
      {loading && <p>lädt...</p>}
      {data && <p>{data.currentDateTime}</p>}
    </div>
  );
}

export default App;
