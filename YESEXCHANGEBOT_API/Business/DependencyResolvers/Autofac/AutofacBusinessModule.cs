using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Authentication;
using Business.Repositories.EmailParameterRepository;
using Business.Repositories.OperationClaimRepository;
using Business.Repositories.UserOperationClaimRepository;
using Business.Repositories.UserRepository;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Repositories.EmailParameterRepository;
using DataAccess.Repositories.OperationClaimRepository;
using DataAccess.Repositories.UserOperationClaimRepository;
using Business.Repositories.StrategyTransactionRepository;
using DataAccess.Repositories.StrategyTransactionRepository;
using Business.Repositories.PairBuySellStrategyRepository;
using DataAccess.Repositories.PairBuySellStrategyRepository;
using Business.Repositories.TradeHistoryRepository;
using DataAccess.Repositories.TradeHistoryRepository;
using Business.Repositories.transactionorderRepository;
using DataAccess.Repositories.transactionorderRepository;
using Business.Repositories.transactionRepository;
using DataAccess.Repositories.transactionRepository;
using Business.Repositories.buysellstrategyRepository;
using DataAccess.Repositories.buysellstrategyRepository;
using DataAccess.Repositories.UserRepository;
using Business.ExchangeBots.OkexBots;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<OperationClaimManager>().As<IOperationClaimService>();
            builder.RegisterType<EfOperationClaimDal>().As<IOperationClaimDal>();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<UserOperationClaimManager>().As<IUserOperationClaimService>();
            builder.RegisterType<EfUserOperationClaimDal>().As<IUserOperationClaimDal>();

            builder.RegisterType<EmailParameterManager>().As<IEmailParameterService>();
            builder.RegisterType<EfEmailParameterDal>().As<IEmailParameterDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();

            builder.RegisterType<TokenHandler>().As<ITokenHandler>();

            builder.RegisterType<StrategyTransactionManager>().As<IStrategyTransactionService>().SingleInstance();
            builder.RegisterType<EfStrategyTransactionDal>().As<IStrategyTransactionDal>().SingleInstance();

            builder.RegisterType<PairBuySellStrategyManager>().As<IPairBuySellStrategyService>().SingleInstance();
            builder.RegisterType<EfPairBuySellStrategyDal>().As<IPairBuySellStrategyDal>().SingleInstance();

            builder.RegisterType<TradeHistoryManager>().As<ITradeHistoryService>().SingleInstance();
            builder.RegisterType<EfTradeHistoryDal>().As<ITradeHistoryDal>().SingleInstance();

            builder.RegisterType<transactionorderManager>().As<ItransactionorderService>().SingleInstance();
            builder.RegisterType<EftransactionorderDal>().As<ItransactionorderDal>().SingleInstance();

            builder.RegisterType<transactionManager>().As<ItransactionService>().SingleInstance();
            builder.RegisterType<EftransactionDal>().As<ItransactionDal>().SingleInstance();

            builder.RegisterType<buysellstrategyManager>().As<IbuysellstrategyService>().SingleInstance();
            builder.RegisterType<EfbuysellstrategyDal>().As<IbuysellstrategyDal>().SingleInstance();

            builder.RegisterType<OkexExchangeBotManager>().As<IOkexExchangeBotService>().SingleInstance();
            

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().EnableInterfaceInterceptors(new Castle.DynamicProxy.ProxyGenerationOptions()
            {
                Selector = new AspectInterceptorSelector()
            }).SingleInstance();
        }
    }
}