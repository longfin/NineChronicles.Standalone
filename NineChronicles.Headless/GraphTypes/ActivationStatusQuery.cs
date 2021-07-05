using Bencodex.Types;
using System;
using GraphQL;
using GraphQL.Types;
using Libplanet;
using Libplanet.Blockchain;
using Libplanet.Crypto;
using Nekoyume.Model.State;
using NineChroniclesActionType = Libplanet.Action.PolymorphicAction<Nekoyume.Action.ActionBase>;
using Log = Serilog.Log;

namespace NineChronicles.Headless.GraphTypes
{
    public class ActivationStatusQuery : ObjectGraphType
    {
        public ActivationStatusQuery(StandaloneContext standaloneContext)
        {
            Field<NonNullGraphType<BooleanGraphType>>(
                name: "activated",
                resolve: context =>
                {
                    var service = standaloneContext.NineChroniclesNodeService;

                    if (service is null)
                    {
                        return false;
                    }

                    try
                    {
                        if (!(service.MinerPrivateKey is { } privateKey))
                        {
                            throw new InvalidOperationException($"{nameof(service.MinerPrivateKey)} is null.");
                        }

                        if (!(service.Swarm?.BlockChain is { } blockChain))
                        {
                            throw new InvalidOperationException($"{nameof(service.Swarm.BlockChain)} is null.");
                        }

                        Address address = privateKey.ToAddress();
                        IValue state = blockChain.GetState(ActivatedAccountsState.Address);

                        if (state is Bencodex.Types.Dictionary asDict)
                        {
                            var activatedAccountsState = new ActivatedAccountsState(asDict);
                            var activatedAccounts = activatedAccountsState.Accounts;
                            return true;
                        }

                        return true;
                    }
                    catch (Exception e)
                    {
                        var msg = "Unexpected exception occurred during ActivationStatusQuery: {e}";
                        context.Errors.Add(new ExecutionError(msg, e));
                        Log.Error(msg, e);
                        return false;
                    }
                }
            );
        }
    }
}
