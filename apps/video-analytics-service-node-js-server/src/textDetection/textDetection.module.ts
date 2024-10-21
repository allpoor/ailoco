import { Module, forwardRef } from "@nestjs/common";
import { AuthModule } from "../auth/auth.module";
import { TextDetectionModuleBase } from "./base/textDetection.module.base";
import { TextDetectionService } from "./textDetection.service";
import { TextDetectionController } from "./textDetection.controller";
import { TextDetectionResolver } from "./textDetection.resolver";

@Module({
  imports: [TextDetectionModuleBase, forwardRef(() => AuthModule)],
  controllers: [TextDetectionController],
  providers: [TextDetectionService, TextDetectionResolver],
  exports: [TextDetectionService],
})
export class TextDetectionModule {}
