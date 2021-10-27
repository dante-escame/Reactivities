import { createContext, useContext } from "react";
import ActivityStore from "./activityStore";

interface Store {
  activityStore: ActivityStore
}

export const store: Store = {
  activityStore: new ActivityStore() // new object with an ActivityStore
}

export const StoreContext = createContext(store);

export function useStore() {
  return useContext(StoreContext); // returns store context
}