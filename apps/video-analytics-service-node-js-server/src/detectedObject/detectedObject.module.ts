import { Module, forwardRef } from "@nestjs/common";
import { AuthModule } from "../auth/auth.module";
import { DetectedObjectModuleBase } from "./base/detectedObject.module.base";
import { DetectedObjectService } from "./detectedObject.service";
import { DetectedObjectController } from "./detectedObject.controller";
import { DetectedObjectResolver } from "./detectedObject.resolver";

@Module({
  imports: [DetectedObjectModuleBase, forwardRef(() => AuthModule)],
  controllers: [DetectedObjectController],
  providers: [DetectedObjectService, DetectedObjectResolver],
  exports: [DetectedObjectService],
})
export class DetectedObjectModule {}
