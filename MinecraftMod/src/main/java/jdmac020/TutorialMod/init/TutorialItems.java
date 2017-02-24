package jdmac020.TutorialMod.init;

import jdmac020.TutorialMod.init.items.currency.CopperCoin;
import jdmac020.TutorialMod.init.items.currency.GoldCoin;
import jdmac020.TutorialMod.init.items.currency.IronCoin;
import jdmac020.TutorialMod.init.items.materials.CopperIngot;
import jdmac020.TutorialMod.init.items.materials.CopperNugget;
import jdmac020.TutorialMod.init.items.materials.IronNugget;
import jdmac020.TutorialMod.init.items.materials.Ruby;
import jdmac020.TutorialMod.main.Reference;
import jdmac020.TutorialMod.main.TutorialMod;
import net.minecraft.client.Minecraft;
import net.minecraft.client.renderer.block.model.ModelResourceLocation;
import net.minecraft.creativetab.CreativeTabs;
import net.minecraft.item.Item;
import net.minecraft.util.ResourceLocation;
import net.minecraftforge.fml.common.registry.GameRegistry;

public class TutorialItems 
{
	//currency
	public static Item GOLD_COIN;
	public static Item IRON_COIN;
	public static Item COPPER_COIN;
	
	//breaks down into nuggets
	public static Item COPPER_INGOT;
	
	//from ores
	public static Item RUBY;
	
	//from ingots, one nugget smelts into 1 coin
	public static Item COPPER_NUGGET;
	public static Item IRON_NUGGET;
	
	
	public static void init()
	{
		
		//Currency
		GOLD_COIN = new GoldCoin("gold_coin");
		COPPER_COIN = new CopperCoin("copper_coin");
		IRON_COIN = new IronCoin("iron_coin");
		
		//from ores
		COPPER_INGOT = new CopperIngot("copper_ingot");
		RUBY = new Ruby("ruby");
		
		//from ignots
		COPPER_NUGGET = new CopperNugget("copper_nugget");
		IRON_NUGGET = new IronNugget("iron_nugget");
	}
	
	public static void register()
	{
		//currency
		registerItem(GOLD_COIN);
		registerItem(IRON_COIN);
		registerItem(COPPER_COIN);
		
		//from ores
		registerItem(COPPER_INGOT);
		registerItem(RUBY);
		
		//from ingots
		registerItem(IRON_NUGGET);
		registerItem(COPPER_NUGGET);
		
	}
	
	public static void registerItem(Item item)
	{
		
		GameRegistry.register(item);
		
		Minecraft.getMinecraft().getRenderItem().getItemModelMesher()
		.register(item, 0, new ModelResourceLocation(Reference.MODID + ":" + item.getUnlocalizedName().substring(5), "inventory"));
	}
}