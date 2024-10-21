import { CameraWhereInput } from "./CameraWhereInput";
import { CameraOrderByInput } from "./CameraOrderByInput";

export type CameraFindManyArgs = {
  where?: CameraWhereInput;
  orderBy?: Array<CameraOrderByInput>;
  skip?: number;
  take?: number;
};
