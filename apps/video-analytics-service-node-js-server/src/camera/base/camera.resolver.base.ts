/*
------------------------------------------------------------------------------ 
This code was generated by Amplication. 
 
Changes to this file will be lost if the code is regenerated. 

There are other ways to to customize your code, see this doc to learn more
https://docs.amplication.com/how-to/custom-code

------------------------------------------------------------------------------
  */
import * as graphql from "@nestjs/graphql";
import { GraphQLError } from "graphql";
import { isRecordNotFoundError } from "../../prisma.util";
import { MetaQueryPayload } from "../../util/MetaQueryPayload";
import * as nestAccessControl from "nest-access-control";
import * as gqlACGuard from "../../auth/gqlAC.guard";
import { GqlDefaultAuthGuard } from "../../auth/gqlDefaultAuth.guard";
import * as common from "@nestjs/common";
import { AclFilterResponseInterceptor } from "../../interceptors/aclFilterResponse.interceptor";
import { Camera } from "./Camera";
import { CameraCountArgs } from "./CameraCountArgs";
import { CameraFindManyArgs } from "./CameraFindManyArgs";
import { CameraFindUniqueArgs } from "./CameraFindUniqueArgs";
import { DeleteCameraArgs } from "./DeleteCameraArgs";
import { CameraService } from "../camera.service";
@common.UseGuards(GqlDefaultAuthGuard, gqlACGuard.GqlACGuard)
@graphql.Resolver(() => Camera)
export class CameraResolverBase {
  constructor(
    protected readonly service: CameraService,
    protected readonly rolesBuilder: nestAccessControl.RolesBuilder
  ) {}

  @graphql.Query(() => MetaQueryPayload)
  @nestAccessControl.UseRoles({
    resource: "Camera",
    action: "read",
    possession: "any",
  })
  async _camerasMeta(
    @graphql.Args() args: CameraCountArgs
  ): Promise<MetaQueryPayload> {
    const result = await this.service.count(args);
    return {
      count: result,
    };
  }

  @common.UseInterceptors(AclFilterResponseInterceptor)
  @graphql.Query(() => [Camera])
  @nestAccessControl.UseRoles({
    resource: "Camera",
    action: "read",
    possession: "any",
  })
  async cameras(@graphql.Args() args: CameraFindManyArgs): Promise<Camera[]> {
    return this.service.cameras(args);
  }

  @common.UseInterceptors(AclFilterResponseInterceptor)
  @graphql.Query(() => Camera, { nullable: true })
  @nestAccessControl.UseRoles({
    resource: "Camera",
    action: "read",
    possession: "own",
  })
  async camera(
    @graphql.Args() args: CameraFindUniqueArgs
  ): Promise<Camera | null> {
    const result = await this.service.camera(args);
    if (result === null) {
      return null;
    }
    return result;
  }

  @graphql.Mutation(() => Camera)
  @nestAccessControl.UseRoles({
    resource: "Camera",
    action: "delete",
    possession: "any",
  })
  async deleteCamera(
    @graphql.Args() args: DeleteCameraArgs
  ): Promise<Camera | null> {
    try {
      return await this.service.deleteCamera(args);
    } catch (error) {
      if (isRecordNotFoundError(error)) {
        throw new GraphQLError(
          `No resource was found for ${JSON.stringify(args.where)}`
        );
      }
      throw error;
    }
  }
}
