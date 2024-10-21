import { Module, forwardRef } from "@nestjs/common";
import { AuthModule } from "../auth/auth.module";
import { CameraModuleBase } from "./base/camera.module.base";
import { CameraService } from "./camera.service";
import { CameraController } from "./camera.controller";
import { CameraResolver } from "./camera.resolver";

@Module({
  imports: [CameraModuleBase, forwardRef(() => AuthModule)],
  controllers: [CameraController],
  providers: [CameraService, CameraResolver],
  exports: [CameraService],
})
export class CameraModule {}
