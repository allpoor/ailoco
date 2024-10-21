import { MovementStatusWhereInput } from "./MovementStatusWhereInput";
import { MovementStatusOrderByInput } from "./MovementStatusOrderByInput";

export type MovementStatusFindManyArgs = {
  where?: MovementStatusWhereInput;
  orderBy?: Array<MovementStatusOrderByInput>;
  skip?: number;
  take?: number;
};
