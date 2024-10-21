import { DetectedObjectWhereInput } from "./DetectedObjectWhereInput";
import { DetectedObjectOrderByInput } from "./DetectedObjectOrderByInput";

export type DetectedObjectFindManyArgs = {
  where?: DetectedObjectWhereInput;
  orderBy?: Array<DetectedObjectOrderByInput>;
  skip?: number;
  take?: number;
};
